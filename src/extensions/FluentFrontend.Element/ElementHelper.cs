using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public class ElementHelper<TModel> : VueHelper<TModel>, IElementHelper
    {
        public ElementHelper(IFluentAdapter<TModel> adapter) : base(adapter)
        {
        }
    }
}
