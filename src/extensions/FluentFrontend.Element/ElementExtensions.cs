using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public static class ElementExtensions
    {
        private const string ValidationErrorsKey = nameof(ValidationErrorsKey);

        public static ElementHelper<TModel> Element<TModel>(this IFluentAdapter<TModel> adapter) => new ElementHelper<TModel>(adapter);

        public static IElement<VueInstance<TData>> ValidationErrors<TData>(this IElement<VueInstance<TData>> instance, string validationErrorsProperty) =>
            instance.SetTagData(ValidationErrorsKey, validationErrorsProperty);

        public static IElement<VueInstance<TData>> ValidationErrors<TData>(this IElement<VueInstance<TData>> instance, Expression<Func<TData, object>> validationErrorsProperty) =>
            instance.SetTagData(ValidationErrorsKey, ExpressionHelper.GetMemberName(validationErrorsProperty, true));

        public static IElement<TTag> OnClick<TTag>(
            this IElement<TTag> element,
            string handler,
            EventModifiers? modifiers = null)
            where TTag : ElementTag =>
            element.VOn("click", handler, modifiers);

        public static IElement<TTag> OnClick<TTag, TData>(
            this IElement<TTag> element,
            ref IElement<VueInstance<TData>> instance,
            string methodBody,
            string methodName = null,
            EventModifiers? modifiers = null)
            where TTag : ElementTag =>
            element.VOn(ref instance, "click", methodBody, methodName, modifiers);

        public static IElement<TTag> For<TTag>(
            this IElement<TTag> element,
            BoundValue value,
            bool formItemWrapper = true, 
            bool tooltipDescription = true) 
            where TTag : ElementTag
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            element = element.VModel(value);

            // Create the form item wrapper
            VueInstanceBoundValue instanceValue = value as VueInstanceBoundValue;
            if (formItemWrapper)
            {
                IElement<FormItem> formItem = element.Tag.Helper.FormItem();
                if (instanceValue != null)
                {
                    formItem = formItem
                        .Label(instanceValue.Metadata.DisplayName)
                        .Required(instanceValue.Metadata.IsRequired);

                    // Set the validation property
                    if (instanceValue.Instance.TagData.TryGetValue(ValidationErrorsKey, out object validationErrorsProperty))
                    {
                        formItem = formItem.Error((BoundValue)$"{validationErrorsProperty}['{value.Value}']");
                    }
                }

                // Add the form item as a parent
                element = element.Parent(formItem);
            }

            // Create the tooltip description
            if (tooltipDescription && !string.IsNullOrWhiteSpace(instanceValue?.Metadata.Description))
            {
                element = element.Child(
                    element.Tag.Helper.Tooltip()
                        .Content(instanceValue.Metadata.Description)
                        .Html("<i class=\"el-icon-information\"></i>"),
                    ChildPosition.AfterClosing);
            }

            return element;
        }
    }
}
