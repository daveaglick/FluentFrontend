using System.Web;

namespace FluentFrontend.Adapter.Webpages
{
    internal class WebpagesElement<TTag> : Element<TTag>, IHtmlString
        where TTag : class, ITag
    {
        public WebpagesElement(IFluentHelper helper, TTag tag) : base(helper, tag)
        {
        }

        public WebpagesElement(Element<TTag> element, ElementData data) : base(element, data)
        {
        }

        protected override IElement<TTag> Clone(ElementData data) => new WebpagesElement<TTag>(this, data);

        public string ToHtmlString()
        {
            return ToString();
        }
    }
}
