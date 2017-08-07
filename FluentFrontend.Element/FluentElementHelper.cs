using System;
using System.Collections.Generic;
using System.Text;
using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public class FluentElementHelper : FluentVueHelper
    {
        public FluentElementHelper(IFluentAdapter adapter) : base(adapter)
        {
        }
    }

    public class FluentElementHelper<TModel> : FluentElementHelper
    {
        public FluentElementHelper(IFluentAdapter<TModel> adapter) : base(adapter)
        {
        }
    }
}
