using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public class ElementHelper : VueHelper
    {
        public ElementHelper(IFluentAdapter adapter) : base(adapter)
        {
        }
    }

    public class ElementHelper<TModel> : ElementHelper
    {
        internal new IFluentAdapter<TModel> Adapter { get; }

        public ElementHelper(IFluentAdapter<TModel> adapter) : base(adapter)
        {
            Adapter = adapter;
        }
    }
}
