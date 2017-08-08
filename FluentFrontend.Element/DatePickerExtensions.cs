using System;
using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public static class DatePickerExtensions
    {
        public static IElement<DatePicker> Readonly(this IElement<DatePicker> element, BoundValue<bool> @readonly) => element.Attribute("readonly", @readonly);
        public static IElement<DatePicker> Disabled(this IElement<DatePicker> element, BoundValue<bool> disabled) => element.Attribute("disabled", disabled);
        public static IElement<DatePicker> Size(this IElement<DatePicker> element, DatePickerSize size) => element.Attribute("size", size);
        public static IElement<DatePicker> Size(this IElement<DatePicker> element, BoundValue size) => element.Attribute("size", size);
        public static IElement<DatePicker> Editable(this IElement<DatePicker> element, BoundValue<bool> editable) => element.Attribute("editable", editable);
        public static IElement<DatePicker> Clearable(this IElement<DatePicker> element, BoundValue<bool> clearable) => element.Attribute("clearable", clearable);
        public static IElement<DatePicker> Placeholder(this IElement<DatePicker> element, string placeholder) => element.Attribute("plaecholder", placeholder);
        public static IElement<DatePicker> Placeholder(this IElement<DatePicker> element, BoundValue placeholder) => element.Attribute("plaecholder", placeholder);
        public static IElement<DatePicker> Type(this IElement<DatePicker> element, DatePickerType type) => element.Attribute("type", type);
        public static IElement<DatePicker> Type(this IElement<DatePicker> element, BoundValue type) => element.Attribute("type", type);
        public static IElement<DatePicker> Format(this IElement<DatePicker> element, string format) => element.Attribute("format", format);
        public static IElement<DatePicker> Format(this IElement<DatePicker> element, BoundValue format) => element.Attribute("format", format);
        public static IElement<DatePicker> Align(this IElement<DatePicker> element, DatePickerAlign align) => element.Attribute("align", align);
        public static IElement<DatePicker> Align(this IElement<DatePicker> element, BoundValue align) => element.Attribute("align", align);
        public static IElement<DatePicker> RangeSeparater(this IElement<DatePicker> element, string rangeSeparator) => element.Attribute("range-separator", rangeSeparator);
        public static IElement<DatePicker> RangeSeparater(this IElement<DatePicker> element, BoundValue rangeSeparator) => element.Attribute("range-separator", rangeSeparator);
        public static IElement<DatePicker> DefaultValue(this IElement<DatePicker> element, BoundValue<DateTime> defaultValue) => element.Attribute("default-value", defaultValue);

        public static IElement<DatePicker> OnChange(this IElement<DatePicker> element, string handler, EventModifiers? modifiers = null) => element.On("change", handler, modifiers);
    }
}