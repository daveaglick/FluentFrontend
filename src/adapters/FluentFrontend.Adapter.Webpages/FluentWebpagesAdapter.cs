using System.IO;

namespace FluentFrontend.Adapter.Webpages
{
    public class FluentWebpagesAdapter : FluentAdapter
    {
        public FluentWebpagesAdapter(TextWriter writer) : base(writer)
        {
        }

        public override IElement<TTag> GetElement<TTag>(TTag tag)
        {
            return new WebpagesElement<TTag>(tag);
        }
    }
}
