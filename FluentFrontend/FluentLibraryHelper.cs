using System;
using System.Collections.Generic;
using System.IO;

namespace FluentFrontend
{
    /// <summary>
    /// This class is helpful when creating libraries of fluent calls that
    /// should all be grouped together. To do so, create a derived class
    /// from this one, wrapping the original <see cref="IFluentHelper"/>
    /// and then make extension methods support the wrapping helper.
    /// </summary>
    public abstract class FluentLibraryHelper : IFluentHelper
    {
        private readonly IFluentHelper _helper;

        protected FluentLibraryHelper(IFluentHelper helper)
        {
            _helper = helper ?? throw new ArgumentNullException(nameof(helper));
        }

        public TextWriter Writer => _helper.Writer;

        public IElement<TTag> GetElement<TTag>(TTag tag)
            where TTag : class, ITag =>
            _helper.GetElement(tag);

        public virtual KeyValuePair<string, string> GetAttribute(string name, object value) => _helper.GetAttribute(name, value);
    }
}