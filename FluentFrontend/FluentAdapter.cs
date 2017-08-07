using System;
using System.IO;

namespace FluentFrontend
{
    public abstract class FluentAdapter : IFluentAdapter
    {
        public TextWriter Writer { get; }

        protected FluentAdapter(TextWriter writer)
        {
            Writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        public virtual IElement<TTag> GetElement<TTag>(IFluentHelper helper, TTag tag) 
            where TTag : class, ITag => 
            new DefaultElement<TTag>(helper, tag);
    }
}