using System.Web;

namespace FluentFrontend.Adapter.Mvc
{
    internal class MvcElement<TTag> : Element<TTag>, IHtmlString
        where TTag : class, ITag
    {
        public MvcElement(IFluentHelper helper, TTag tag) : base(helper, tag)
        {
        }

        public MvcElement(Element<TTag> element, ElementData data) : base(element, data)
        {
        }

        protected override IElement<TTag> Clone(ElementData data) => new MvcElement<TTag>(this, data);

        public string ToHtmlString()
        {
            return ToString();
        }
    }
}