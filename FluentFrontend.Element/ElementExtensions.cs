using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FluentFrontend.Element
{
    public static class ElementExtensions
    {
        public static FluentElementHelper Element(this IFluentAdapter adapter) => new FluentElementHelper(adapter);

        public static IElement<Tooltip.Tooltip> Tooltip(this FluentElementHelper helper) => helper.GetElement(new Tooltip.Tooltip());

        public static IElement<DatePicker.DatePicker> DatePicker(this FluentElementHelper helper) => helper.GetElement(new DatePicker.DatePicker());

        // Model-Bound

        public static FluentElementHelper<TModel> Element<TModel>(this IFluentAdapter<TModel> adapter) => new FluentElementHelper<TModel>(adapter);

        //public static IElement<DatePicker.DatePicker> DatePickerFor<TModel, TProperty>(
        //    this FluentElementHelper<TModel> helper,
        //    Expression<Func<TModel, TProperty>> expression,
        //    string dataProperty = null,
        //    string validationErrorsProperty = "validationErrors",
        //    bool formItemWrapper = true,
        //    bool tooltipDescription = true) =>
        //    helper.GetElement(new DatePicker.DatePicker())
    }
}
