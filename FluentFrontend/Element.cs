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
        private readonly IFluentHelper _helper;
        private readonly TTag _tag;
        private readonly ElementData _data;
        
        protected Element(IFluentHelper helper, TTag tag)
        {
            _helper = helper ?? throw new ArgumentNullException(nameof(helper));
            _tag = tag ?? throw new ArgumentNullException(nameof(tag));
            _data = new ElementData(helper);
        }

        protected Element(Element<TTag> element, ElementData data)
        {
            _helper = element?._helper ?? throw new ArgumentNullException(nameof(element));
            _tag = element._tag;
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        protected abstract IElement<TTag> Clone(ElementData data);

        public IElement<TTag> Attribute(string name, object value) => Clone(_data.Attribute(name, value));

        public IElement<TTag> Style(string name, string value) => Clone(_data.Style(name, value));

        public IElement<TTag> Class(params string[] classes) => Clone(_data.Class(classes));

        public IElement<TTag> RemoveClass(params string[] classes) => Clone(_data.RemoveClass(classes));

        /// <inheritdoc />
        public void Write() => Write(_helper.Writer);

        /// <inheritdoc />
        public void Write(TextWriter writer) => Begin(writer).Dispose();

        /// <inheritdoc />
        public IDisposable Begin() => Begin(_helper.Writer);

        /// <inheritdoc />
        public IDisposable Begin(TextWriter writer)
        {
            _tag.Begin(writer, _data);
            return new ActionDisposable(() => _tag.End(writer, _data));
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