using System;
using System.Collections.Immutable;
using System.IO;

namespace FluentFrontend
{
    public interface IElement
    {
        /// <summary>
        /// Writes all content (beginning and ending) to the <see cref="TextWriter"/>
        /// in the <see cref="FluentHelper"/>.
        /// </summary>
        void Write();

        /// <summary>
        /// Writes all content (beginning and ending) to the specified <see cref="TextWriter"/>.
        /// </summary>
        /// <param name="writer">The <see cref="TextWriter"/> to write to.</param>
        void Write(TextWriter writer);

        /// <summary>
        /// Writes the beginning content to the <see cref="TextWriter"/>
        /// in the <see cref="FluentHelper"/>. The ending content will
        /// be written when the returned object is disposed. 
        /// </summary>
        /// <returns>An object that will write the ending content when disposed.</returns>
        IDisposable Begin();

        /// <summary>
        /// Writes the beginning content to the specified
        /// <see cref="TextWriter"/>. The ending content will
        /// be written when the returned object is disposed.
        /// </summary>
        /// <param name="writer">The <see cref="TextWriter"/> to write to.</param>
        /// <returns>An object that will write the ending content when disposed.</returns>
        IDisposable Begin(TextWriter writer);
    }

    public interface IElement<out TTag> : IElement
        where TTag : class, ITag
    {
        TTag Tag { get; }
        IImmutableDictionary<string, string> Attributes { get; }
        IImmutableDictionary<string, string> Styles { get; }
        IImmutableSet<string> Classes { get; }
        IImmutableList<ElementChild> Children { get; }
        IImmutableList<IElement> Parents { get; }
        IImmutableDictionary<string, object> TagData { get; }

        IElement<TTag> Attribute(string name, object value);
        IElement<TTag> Style(string name, string value);
        IElement<TTag> Class(params string[] classes);
        IElement<TTag> Child(IElement child, ChildPosition position = ChildPosition.AfterOpening);
        IElement<TTag> Parent(IElement parent);
        IElement<TTag> Text(object text, ChildPosition position = ChildPosition.AfterOpening);
        IElement<TTag> Html(string html, ChildPosition position = ChildPosition.AfterOpening);
        IElement<TTag> Id(string id);

        IElement<TTag> RemoveClass(params string[] classes);
        IElement<TTag> EditChildren(Func<IImmutableList<ElementChild>, IImmutableList<ElementChild>> edit);
        IElement<TTag> EditParents(Func<IImmutableList<IElement>, IImmutableList<IElement>> edit);

        IElement<TTag> SetTagData(string key, object value);
        IElement<TTag> SetTagData(string key, Func<object, object> valueFunc, object defaultValue = null);
        IElement<TTag> SetTagData<TValue>(string key, Func<TValue, TValue> valueFunc, TValue defaultValue = default(TValue));
    }
}