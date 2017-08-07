﻿using System;
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
        public static IFluentAdapter Fluent(this HtmlHelper htmlHelper, WebPageBase webPageBase)
        {
            return new FluentWebpagesAdapter(webPageBase.Output);
        }
    }
}
