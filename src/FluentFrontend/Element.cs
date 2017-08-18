using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace FluentFrontend
{
    /// <summary>
    /// An immutable implementation of an HTML element for a specific tag.
    /// Contains all the logic for storing information about the element
    /// and rendering it.
    /// </summary>
    /// <remarks>
    /// If a library for a specific framework needs to implement a specialized
    /// element class, for example to make it implement <c>IHtmlString</c> or
    /// similar, it should derived from this element class and override the
    /// <c>Clone</c> method. A cooreponsing <see cref="IFluentHelper"/> should
    /// also be created that will generate the specialized element objects.
    /// </remarks>
    /// <typeparam name="TTag">The typeof tag for this element.</typeparam>
    public abstract class Element<TTag> : IElement<TTag>
        where TTag : class, ITag
    {
        private readonly ElementData _data;

        public TTag Tag { get; }
        
        protected Element(TTag tag)
        {
            Tag = tag ?? throw new ArgumentNullException(nameof(tag));
            _data = new ElementData(tag.Helper);
        }

        protected Element(IElement<TTag> element, ElementData data)
        {
            Tag = element.Tag;
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        protected abstract IElement<TTag> Clone(ElementData data);
        
        public IImmutableDictionary<string, string> Attributes => _data.Attributes;

        public IImmutableDictionary<string, string> Styles => _data.Styles;

        public IImmutableSet<string> Classes => _data.Classes;

        public IImmutableList<ElementChild> Children => _data.Children;

        public IImmutableList<IElement> Parents => _data.Parents;

        public IImmutableDictionary<string, object> TagData => _data.TagData;

        public IElement<TTag> Attribute(string name, object value) => Clone(_data.Attribute(name, value));

        public IElement<TTag> Style(string name, string value) => Clone(_data.Style(name, value));

        public IElement<TTag> Class(params string[] classes) => Clone(_data.Class(classes));

        public IElement<TTag> Child(IElement child, ChildPosition position = ChildPosition.AfterOpening) => 
            Clone(_data.Child(child, position));

        public IElement<TTag> Parent(IElement parent) =>
            Clone(_data.Parent(parent));

        public IElement<TTag> Text(object text, ChildPosition position = ChildPosition.AfterOpening) =>
            Clone(_data.Child(new ContentElement(Tag.Helper.Adapter.Writer, text?.ToString(), true), position));

        public IElement<TTag> Html(string html, ChildPosition position = ChildPosition.AfterOpening) =>
            Clone(_data.Child(new ContentElement(Tag.Helper.Adapter.Writer, html, false), position));

        public IElement<TTag> RemoveClass(params string[] classes) => Clone(_data.RemoveClass(classes));

        public IElement<TTag> EditChildren(Func<IImmutableList<ElementChild>, IImmutableList<ElementChild>> edit) => 
            Clone(_data.EditChildren(edit));

        public IElement<TTag> EditParents(Func<IImmutableList<IElement>, IImmutableList<IElement>> edit) =>
            Clone(_data.EditParents(edit));

        public IElement<TTag> SetTagData(string key, object value) => Clone(_data.SetTagData(key, value));

        public IElement<TTag> SetTagData(string key, Func<object, object> valueFunc, object defaultValue = null) =>
            Clone(_data.SetTagData(key, valueFunc, defaultValue));

        public IElement<TTag> SetTagData<TValue>(string key, Func<TValue, TValue> valueFunc, TValue defaultValue = default(TValue)) =>
            Clone(_data.SetTagData(key, valueFunc, defaultValue));

        public IElement<TTag> Id(string id) => Attribute("id", id);

        /// <inheritdoc />
        public void Write() => Write(Tag.Helper.Adapter.Writer);

        /// <inheritdoc />
        public void Write(TextWriter writer) => Begin(writer).Dispose();

        /// <inheritdoc />
        public IDisposable Begin() => Begin(Tag.Helper.Adapter.Writer);

        /// <inheritdoc />
        public IDisposable Begin(TextWriter writer)
        {
            Stack<IDisposable> parents = new Stack<IDisposable>(_data.Parents.Select(x => x.Begin(writer)));
            WriteChildren(ChildPosition.BeforeOpening, writer);
            Tag.Begin(writer, _data);
            WriteChildren(ChildPosition.AfterOpening, writer);
            return new ActionDisposable(() =>
            {
                WriteChildren(ChildPosition.BeforeClosing, writer);
                Tag.End(writer, _data);
                WriteChildren(ChildPosition.AfterClosing, writer);
                foreach (IDisposable parent in parents)
                {
                    parent.Dispose();
                }
            });
        }

        private void WriteChildren(ChildPosition position, TextWriter writer)
        {
            foreach (IElement child in _data.Children
                .Where(x => x.Position == position)
                .Select(x => x.Element))
            {
                child.Write(writer);
            }
        }

        public override string ToString()
        {
            using (StringWriter writer = new StringWriter())
            {
                Write(writer);
                return writer.ToString();
            }
        }
    }
}