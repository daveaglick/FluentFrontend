using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentFrontend.Adapter.Mvc
{
    public static class HtmlHelperExtensions
    {
        public static IFluentAdapter<dynamic> Fluent(this HtmlHelper htmlHelper) => 
            new FluentMvcAdapter<dynamic>(htmlHelper.ViewContext.Writer, null);

        public static IFluentAdapter<TModel> Fluent<TModel>(this HtmlHelper htmlHelper, TModel model) => 
            new FluentMvcAdapter<TModel>(htmlHelper.ViewContext.Writer, model);

        public static IFluentAdapter<TModel> Fluent<TModel>(this HtmlHelper<TModel> htmlHelper) => 
            new FluentMvcAdapter<TModel>(
                htmlHelper.ViewContext.Writer,
                htmlHelper.ViewData == null ? default(TModel) : htmlHelper.ViewData.Model);
    }
}
