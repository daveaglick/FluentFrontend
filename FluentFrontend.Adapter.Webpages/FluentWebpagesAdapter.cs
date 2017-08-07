using System.IO;

namespace FluentFrontend.Adapter.Webpages
{
    public class FluentWebpagesAdapter : FluentAdapter
    {
        public FluentWebpagesAdapter(TextWriter writer) : base(writer)
        {
        }

        public override IElement<TTag> GetElement<TTag>(IFluentHelper helper, TTag tag)
        {
            return new WebpagesElement<TTag>(helper, tag);
        }
    }
}
