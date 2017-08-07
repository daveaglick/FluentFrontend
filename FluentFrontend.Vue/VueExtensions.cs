using System;
using System.Collections.Generic;
using System.Text;

namespace FluentFrontend.Vue
{
    public static class VueExtensions
    {
        public static FluentVueHelper Vue(this IFluentHelper helper) => new FluentVueHelper(helper);
    }
}
