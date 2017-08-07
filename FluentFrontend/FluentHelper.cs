using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FluentFrontend
{
    /// <summary>
    /// Provides the glue between the outside host environment and frontend components.
    /// Instantiate this directly if you just want to write to a specified <see cref="TextWriter"/>.
    /// </summary>
    /// <remarks>
    /// This class is responsible for creating elements. By
    /// having the helper create element instances, we can specialize
    /// the elements for the host enviornment (I.e., by implementing
    /// interfaces like <c>IHtmlString</c>). To support a new adapter,
    /// a specialized element class should be created and a specialized
    /// helper should return instances of the specialized element class.
    /// </remarks>
    public abstract class FluentHelper : IFluentHelper
    {
        public TextWriter Writer { get; }

        protected FluentHelper(TextWriter writer)
        {
            Writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        public virtual IElement<TTag> GetElement<TTag>(TTag tag) 
            where TTag : class, ITag => 
            new DefaultElement<TTag>(this, tag);

        public virtual KeyValuePair<string, string> GetAttribute(string name, object value)
        {
            if (value is Enum e)
            {
                value = new string(
                    e.ToString()
                        .ToCharArray()
                        .SelectMany((c, i) => i != 0 && char.IsUpper(c) ? new[] { '-', c } : new[] { c })
                        .ToArray())
                    .ToLower();
            }
            return new KeyValuePair<string, string>(name, value.ToString());
        }
    }
}
