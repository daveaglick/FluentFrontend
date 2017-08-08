using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        private readonly IFluentAdapter<TModel> _adapter;

        public FluentElementHelper(IFluentAdapter<TModel> adapter) : base(adapter)
        {
            _adapter = adapter;
        }

        internal IModelMetadata GetModelMetadata<TProperty>(Expression<Func<TModel, TProperty>> expression) =>
            _adapter.GetModelMetadata(expression);
    }
}
