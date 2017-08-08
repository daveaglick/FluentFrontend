using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public static class ElementExtensions
    {
        public static FluentElementHelper Element(this IFluentAdapter adapter) => new FluentElementHelper(adapter);

        public static IElement<Tooltip> Tooltip(this FluentElementHelper helper) => helper.GetElement(new Tooltip());

        public static IElement<DatePicker> DatePicker(this FluentElementHelper helper) => helper.GetElement(new DatePicker());

        public static IElement<FormItem> FormItem(this FluentElementHelper helper) => helper.GetElement(new FormItem());

        // Model-Bound

        public static FluentElementHelper<TModel> Element<TModel>(this IFluentAdapter<TModel> adapter) => new FluentElementHelper<TModel>(adapter);

        public static IElement<DatePicker> DatePickerFor<TModel, TProperty>(
            this FluentElementHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            string dataProperty = null,
            string validationErrorsProperty = "validationErrors",
            bool formItemWrapper = true,
            bool tooltipDescription = true) =>
            helper.DatePicker().For(
                helper,
                expression,
                dataProperty,
                validationErrorsProperty,
                formItemWrapper,
                tooltipDescription);

        private static IElement<TTag> For<TTag, TModel, TProperty>(
            this IElement<TTag> element,
            FluentElementHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            string dataProperty, 
            string validationErrorsProperty, 
            bool formItemWrapper, 
            bool tooltipDescription) 
            where TTag : VueTag
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            IModelMetadata metadata = helper.GetModelMetadata(expression);
            if (metadata == null)
            {
                throw new Exception("Could not get model metadata.");
            }

            // Set the model based on the binding
            string modelProperty = $"{(string.IsNullOrWhiteSpace(dataProperty) ? string.Empty : dataProperty + ".")}{metadata.PropertyName}";
            element = element.Model(modelProperty);

            // Create the form item wrapper
            if (formItemWrapper)
            {
                IElement<FormItem> formItem = helper.FormItem()
                    .Label(metadata.DisplayName)
                    .Required(metadata.IsRequired);
                if (!string.IsNullOrWhiteSpace(validationErrorsProperty))
                {
                    formItem = formItem.Error((BoundValue)$"{validationErrorsProperty}['{modelProperty}']");
                }
                element = element.Parent(formItem);
            }

            // Create the tooltip description
            if (tooltipDescription && !string.IsNullOrWhiteSpace(metadata.Description))
            {
                element = element.Child(
                    helper.Tooltip()
                        .Content(metadata.Description)
                        .Html("<i class=\"el-icon-information\"></i>"),
                    ChildPosition.AfterClosing);
            }

            return element;
        }
    }
}
