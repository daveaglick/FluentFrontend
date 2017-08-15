using System.IO;

namespace FluentFrontend.Adapter.Webpages
{
    public class FluentWebpagesAdapter<TModel> : FluentAdapter<TModel>
    {
        public FluentWebpagesAdapter(TextWriter writer, TModel model) : base(writer, model)
        {
        }

        public override IElement<TTag> GetElement<TTag>(TTag tag) => new WebpagesElement<TTag>(tag);
    }
}
