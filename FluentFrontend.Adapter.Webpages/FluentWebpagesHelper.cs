using System.IO;

namespace FluentFrontend.Adapter.Webpages
{
    public class FluentWebpagesHelper : FluentHelper
    {
        public FluentWebpagesHelper(TextWriter writer) : base(writer)
        {
        }

        public override IElement<TTag> GetElement<TTag>(TTag tag)
        {
            return new WebpagesElement<TTag>(this, tag);
        }
    }
}
