using System;
using System.Linq.Expressions;
using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public class Select : VueTag
    {
        internal FluentElementHelper Helper { get; }

        public Select(FluentElementHelper helper) : base("el-select")
        {
            Helper = helper;
        }
    }

    public static class SelectExtensions
    {
        public static IElement<Select> Select(this FluentElementHelper helper) => helper.GetElement(new Select(helper));

        public static IElement<Select> Multiple(this IElement<Select> element, BoundValue<bool> multiple) => element.Attribute("multiple", multiple);
        public static IElement<Select> Disabled(this IElement<Select> element, BoundValue<bool> disabled) => element.Attribute("disabled", disabled);
        public static IElement<Select> ValueKey(this IElement<Select> element, BoundValue<bool> valueKey) => element.Attribute("value-key", valueKey);
        public static IElement<Select> Size(this IElement<Select> element, SelectSize size) => element.Attribute("size", size);
        public static IElement<Select> Size(this IElement<Select> element, BoundValue size) => element.Attribute("size", size);
        public static IElement<Select> Clearable(this IElement<Select> element, BoundValue<bool> clearable) => element.Attribute("clearable", clearable);
        public static IElement<Select> MultipleLimit(this IElement<Select> element, BoundValue<int> multipleLimit) => element.Attribute("multiple-limit", multipleLimit);
        public static IElement<Select> Name(this IElement<Select> element, string name) => element.Attribute("name", name);
        public static IElement<Select> Name(this IElement<Select> element, BoundValue name) => element.Attribute("name", name);
        public static IElement<Select> Placeholder(this IElement<Select> element, string placeholder) => element.Attribute("placeholder", placeholder);
        public static IElement<Select> Placeholder(this IElement<Select> element, BoundValue placeholder) => element.Attribute("placeholder", placeholder);
        public static IElement<Select> Filterable(this IElement<Select> element, BoundValue<bool> filterable) => element.Attribute("filterable", filterable);
        public static IElement<Select> AllowCreate(this IElement<Select> element, BoundValue<bool> allowCreate) => element.Attribute("allow-create", allowCreate);
        public static IElement<Select> FilterMethod(this IElement<Select> element, BoundValue filterMethod) => element.Attribute("filter-method", filterMethod);
        public static IElement<Select> LoadingText(this IElement<Select> element, string loadingText) => element.Attribute("loading-text", loadingText);
        public static IElement<Select> LoadingText(this IElement<Select> element, BoundValue loadingText) => element.Attribute("loading-text", loadingText);
        public static IElement<Select> NoMatchText(this IElement<Select> element, string noMatchText) => element.Attribute("no-match-text", noMatchText);
        public static IElement<Select> NoMatchText(this IElement<Select> element, BoundValue noMatchText) => element.Attribute("no-match-text", noMatchText);
        public static IElement<Select> NoDataText(this IElement<Select> element, string noDataText) => element.Attribute("no-data-text", noDataText);
        public static IElement<Select> NoDataText(this IElement<Select> element, BoundValue noDataText) => element.Attribute("no-data-text", noDataText);
        public static IElement<Select> DefaultFirstOption(this IElement<Select> element, BoundValue<bool> defaultFirstOption) => element.Attribute("default-first-option", defaultFirstOption);

        public static IElement<Select> OnChange(this IElement<Select> element, string handler, EventModifiers? modifiers = null) => element.On("change", handler, modifiers);
        public static IElement<Select> OnVisibleChange(this IElement<Select> element, string handler, EventModifiers? modifiers = null) => element.On("visible-change", handler, modifiers);
        public static IElement<Select> OnRemoveTag(this IElement<Select> element, string handler, EventModifiers? modifiers = null) => element.On("remove-tag", handler, modifiers);
        public static IElement<Select> OnClear(this IElement<Select> element, string handler, EventModifiers? modifiers = null) => element.On("clear", handler, modifiers);

        public static IElement<Select> Options(this IElement<Select> element, string property, string label, string value)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            IElement<Option> option = element.Tag.Helper.Option().For(property);

            if (label != null)
            {
                option = option.Label((BoundValue)$"item.{label}");
            }

            if (value != null)
            {
                option = option.Value((BoundValue)$"item.{value}");
            }
            
            return element.Child(option);
        }

        public static IElement<Select> Remote<TResult>(
            this IElement<Select> element,
            string remoteMethod,
            string loadingProperty,
            string optionsProperty,
            Expression<Func<TResult, object>> labelExpression,
            Expression<Func<TResult, object>> valueExpression)
            where TResult : class, new()
        {
            if (remoteMethod == null)
            {
                throw new ArgumentNullException(nameof(remoteMethod));
            }
            if (loadingProperty == null)
            {
                throw new ArgumentNullException(nameof(loadingProperty));
            }
            if (optionsProperty == null)
            {
                throw new ArgumentNullException(nameof(optionsProperty));
            }
            if (labelExpression == null)
            {
                throw new ArgumentNullException(nameof(labelExpression));
            }
            if (valueExpression == null)
            {
                throw new ArgumentNullException(nameof(valueExpression));
            }

            string label = ModelMetadata.FromLambdaExpression(labelExpression, new ViewDataDictionary<TResult>()).PropertyName;
            string value = ModelMetadata.FromLambdaExpression(valueExpression, new ViewDataDictionary<TResult>()).PropertyName;
            return Filterable(true)
                .Attribute("remote", string.Empty)
                .Attribute("remote-method", (BoundValue)remoteMethod)
                .Attribute("loading", (BoundValue)loadingProperty)
                .Options(optionsProperty, label, value);
        }
    }

    public enum SelectSize
    {
        Large,
        Small,
        Mini
    }
}