using System;
using System.Collections.Generic;
using System.IO;

namespace FluentFrontend
{
    public class FluentWriter : IFluentAdapter
    {
        public TextWriter Writer { get; }

        public FluentWriter(TextWriter writer)
        {
            Writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        public IElement<TTag> GetElement<TTag>(IFluentHelper helper, TTag tag)
            where TTag : class, ITag =>
            new DefaultElement<TTag>(helper, tag);
    }
}