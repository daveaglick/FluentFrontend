using System;
using System.Linq.Expressions;
using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public class Select : ElementTag
    {
        internal Select(IElementHelper helper) : base(helper, "el-select")
        {
        }
    }

    public static class SelectExtensions
    {
        // Element

        public static IElement<Select> Select(this IElementHelper helper) => helper.Adapter.GetElement(new Select(helper));

        // Attributes

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

        // Events

        public static IElement<Select> OnChange(this IElement<Select> element, string handler, EventModifiers? modifiers = null) => element.VOn("change", handler, modifiers);

        public static IElement<Select> OnVisibleChange(this IElement<Select> element, string handler, EventModifiers? modifiers = null) => element.VOn("visible-change", handler, modifiers);

        public static IElement<Select> OnRemoveTag(this IElement<Select> element, string handler, EventModifiers? modifiers = null) => element.VOn("remove-tag", handler, modifiers);

        public static IElement<Select> OnClear(this IElement<Select> element, string handler, EventModifiers? modifiers = null) => element.VOn("clear", handler, modifiers);

        // Other

        public static IElement<Select> Options(this IElement<Select> element, string property, string label, string value)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }
            
            IElement<Option> option = element.Tag.Helper.Option().VFor(property);

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

            return element.Filterable(true)
                .Attribute("remote", string.Empty)
                .Attribute("remote-method", (BoundValue)remoteMethod)
                .Attribute("loading", (BoundValue)loadingProperty)
                .Options(
                    optionsProperty,
                    ExpressionHelper.GetMemberName(labelExpression),
                    ExpressionHelper.GetMemberName(valueExpression));
        }
    }

    public enum SelectSize
    {
        Large,
        Small,
        Mini
    }
}