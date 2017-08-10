using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FluentFrontend
{
    public abstract class FluentHelper : IFluentHelper
    {
        private readonly IFluentAdapter _adapter;

        protected FluentHelper(IFluentAdapter adapter)
        {
            _adapter = adapter ?? throw new ArgumentNullException(nameof(adapter));
        }

        public TextWriter Writer => _adapter.Writer;

        public IElement<TTag> GetElement<TTag>(TTag tag)
            where TTag : class, ITag =>
            _adapter.GetElement(this, tag);

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
