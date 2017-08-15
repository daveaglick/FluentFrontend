using System.Collections.Generic;
using System.Text;

namespace FluentFrontend.Html
{
    public static class HtmlExtensions
    {
        public static HtmlHelper<TModel> Html<TModel>(this IFluentAdapter<TModel> adapter) => new HtmlHelper<TModel>(adapter);

        public static IElement<HtmlTag> Html<TModel>(this IFluentAdapter<TModel> adapter, string name, bool emptyElement = false) =>
            adapter.GetElement(new HtmlTag(new HtmlHelper<TModel>(adapter), name, emptyElement));

        public static IElement<HtmlTag> P(this IHtmlHelper helper) => helper.Adapter.GetElement(new HtmlTag(helper, "p"));

        public static IElement<HtmlTag> Div(this IHtmlHelper helper) => helper.Adapter.GetElement(new HtmlTag(helper, "p"));
    }
}
