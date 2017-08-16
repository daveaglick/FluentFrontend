using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public static class ElementExtensions
    {
        public static ElementHelper<TModel> Element<TModel>(this IFluentAdapter<TModel> adapter) => new ElementHelper<TModel>(adapter);
        
        public static VueElementHelper<TModel> Element<TModel>(this VueHelper<TModel> vue) => new VueElementHelper<TModel>(vue.Adapter, vue);
        
        public static IElement<TTag> For<TTag, TModel, TProperty>(
            this IElement<TTag> element,
            ElementHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> dataProperty,
            bool formItemWrapper = true, 
            bool tooltipDescription = true) 
            where TTag : ElementTag
        {
            if (dataProperty == null)
            {
                throw new ArgumentNullException(nameof(dataProperty));
            }

            IModelMetadata metadata = helper.Adapter.GetModelMetadata(dataProperty);
            if (metadata == null)
            {
                throw new Exception("Could not get model metadata.");
            }

            // Set the model based on the binding
            string modelProperty = metadata.NestedPropertyName;
            element = element.Model(modelProperty);

            // Create the form item wrapper
            if (formItemWrapper)
            {
                IElement<FormItem> formItem = helper.FormItem()
                    .Label(metadata.DisplayName)
                    .Required(metadata.IsRequired);
                if (!string.IsNullOrWhiteSpace(helper.ValidationErrorsProperty))
                {
                    formItem = formItem.Error((BoundValue)$"{helper.ValidationErrorsProperty}['{modelProperty}']");
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
