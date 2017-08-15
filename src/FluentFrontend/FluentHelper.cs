using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace FluentFrontend
{
    public abstract class FluentHelper<TModel> : IFluentHelper<TModel>
    {
        public IFluentAdapter<TModel> Adapter { get; }

        IFluentAdapter IFluentHelper.Adapter => Adapter;

        protected FluentHelper(IFluentAdapter<TModel> adapter)
        {
            Adapter = adapter ?? throw new ArgumentNullException(nameof(adapter));
        }

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
            return new KeyValuePair<string, string>(
                name,
                WebUtility.HtmlEncode(value.ToString()));  // HTML encoding also works for attributes
        }
    }
}
