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
        private readonly IFluentAdapter<TModel> _adapter;

        public ElementHelper(IFluentAdapter<TModel> adapter) : base(adapter)
        {
            _adapter = adapter;
        }

        internal IModelMetadata GetModelMetadata<TProperty>(Expression<Func<TModel, TProperty>> expression) =>
            _adapter.GetModelMetadata(expression);
    }
}
