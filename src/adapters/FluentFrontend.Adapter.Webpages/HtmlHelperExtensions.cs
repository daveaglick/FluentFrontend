using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;
using System.Web.WebPages.Html;
using FluentFrontend;

namespace FluentFrontend.Adapter.Webpages
{
    public static class HtmlHelperExtensions
    {
        public static IFluentAdapter<dynamic> Fluent(this HtmlHelper htmlHelper, WebPageBase webPageBase)
        {
            if (webPageBase == null)
            {
                throw new ArgumentNullException(nameof(webPageBase));
            }
            return new FluentWebpagesAdapter<dynamic>(webPageBase.Output, null);
        }

        public static IFluentAdapter<TModel> Fluent<TModel>(this HtmlHelper htmlHelper, WebPageBase webPageBase, TModel model)
        {
            if (webPageBase == null)
            {
                throw new ArgumentNullException(nameof(webPageBase));
            }
            return new FluentWebpagesAdapter<TModel>(webPageBase.Output, model);
        }
    }
}
