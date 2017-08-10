using System.Collections.Generic;
using System.Text;

namespace FluentFrontend.Html
{
    public static class HtmlExtensions
    {
        public static HtmlHelper Html(this IFluentAdapter adapter) => new HtmlHelper(adapter);

        public static IElement<HtmlTag> Html(this IFluentAdapter adapter, string name, bool emptyElement = false) =>
            adapter.GetElement(new HtmlTag(new HtmlHelper(adapter), name, emptyElement));

        public static IElement<HtmlTag> P(this HtmlHelper helper) => helper.Adapter.GetElement(new HtmlTag(helper, "p"));

        public static IElement<HtmlTag> Div(this HtmlHelper helper) => helper.Adapter.GetElement(new HtmlTag(helper, "p"));
    }
}
