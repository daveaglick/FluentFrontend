using System.IO;

namespace FluentFrontend.Adapter.Mvc
{
    public class FluentMvcAdapter : FluentAdapter
    {
        public FluentMvcAdapter(TextWriter writer) : base(writer)
        {
        }

        public override IElement<TTag> GetElement<TTag>(IFluentHelper helper, TTag tag)
        {
            return new MvcElement<TTag>(helper, tag);
        }
    }
}