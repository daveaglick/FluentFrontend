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

    public interface IElement<TTag> : IElement
        where TTag : class, ITag
    {
        IElement<TTag> Attribute(string name, object value);
        IElement<TTag> Style(string name, string value);
        IElement<TTag> Class(params string[] classes);
        IElement<TTag> RemoveClass(params string[] classes);
    }
}