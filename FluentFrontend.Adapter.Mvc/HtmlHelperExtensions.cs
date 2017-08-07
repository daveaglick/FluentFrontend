﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentFrontend.Adapter.Mvc
{
    public static class HtmlHelperExtensions
    {
        public static IFluentHelper Fluent(this HtmlHelper htmlHelper)
        {
            return new FluentMvcHelper(htmlHelper.ViewContext.Writer);
        }
    }
}
