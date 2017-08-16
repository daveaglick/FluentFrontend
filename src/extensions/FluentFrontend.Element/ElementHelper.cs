using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public class ElementHelper<TModel> : VueHelper<TModel>, IElementHelper
    {
        public string ValidationErrorsProperty { get; internal set; }

        public ElementHelper(IFluentAdapter<TModel> adapter) : base(adapter)
        {
        }
    }

    public static class ElementHelperExtensions
    {
        public static ElementHelper<TModel> ValidationErrorsProperty<TModel>(this ElementHelper<TModel> helper, string validationErrorProperty)
        {
            helper.ValidationErrorsProperty = validationErrorProperty;
            return helper;
        }

        public static ElementHelper<TModel> ValidationErrorsProperty<TModel>(this ElementHelper<TModel> helper, Expression<Func<TModel, object>> validationErrorProperty)
        {
            helper.ValidationErrorsProperty = ExpressionHelper.GetMemberName(validationErrorProperty, true);
            return helper;
        }

        // Need to duplicate any extensions for VueElementHelper<TModel> because generic inference can't handle a generic THelper type parameter

        public static VueElementHelper<TModel> ValidationErrorsProperty<TModel>(this VueElementHelper<TModel> helper, string validationErrorProperty)
        {
            helper.ValidationErrorsProperty = validationErrorProperty;
            return helper;
        }

        public static VueElementHelper<TModel> ValidationErrorsProperty<TModel>(this VueElementHelper<TModel> helper, Expression<Func<TModel, object>> validationErrorProperty)
        {
            helper.ValidationErrorsProperty = ExpressionHelper.GetMemberName(validationErrorProperty, true);
            return helper;
        }
    }
}
