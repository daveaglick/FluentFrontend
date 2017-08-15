using System.Collections.Generic;
using System.IO;

namespace FluentFrontend
{
    public interface IFluentHelper
    {
        IFluentAdapter Adapter { get; }
        
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

    public interface IFluentHelper<TModel> : IFluentHelper
    {
        new IFluentAdapter<TModel> Adapter { get; }
    }
}