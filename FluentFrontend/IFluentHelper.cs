using System.Collections.Generic;
using System.IO;

namespace FluentFrontend
{
    public interface IFluentHelper
    {
        /// <summary>
        /// Constructs an element given a tag.
        /// </summary>
        /// <typeparam name="TTag">The type of tag to create.</typeparam>
        /// <param name="tag">An instance of the specified tag.</param>
        /// <returns>A new element.</returns>
        IElement<TTag> GetElement<TTag>(TTag tag) where TTag : class, ITag;

        /// <summary>
        /// The <see cref="TextWriter"/> to write to by default.
        /// </summary>
        TextWriter Writer { get; }

        /// <summary>
        /// Allows the helper to customize how objects are converted to
        /// attribute values for the element. The default implementation
        /// calls <c>ToString</c>.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <param name="value">The value to convert.</param>
        /// <returns>The string attribute value for use in the element.</returns>
        KeyValuePair<string, string> GetAttribute(string name, object value);
    }
}