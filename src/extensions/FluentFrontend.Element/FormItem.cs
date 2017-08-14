using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public class FormItem : ElementTag
    {
        internal FormItem(ElementHelper helper) : base(helper, "el-form-item")
        {
        }
    }

    public static class FormItemExtensions
    {
        // Element

        public static IElement<FormItem> FormItem(this ElementHelper helper) => helper.Adapter.GetElement(new FormItem(helper));

        // Attributes

        public static IElement<FormItem> Prop(this IElement<FormItem> element, string prop) => element.Attribute("prop", prop);

        public static IElement<FormItem> Prop(this IElement<FormItem> element, BoundValue prop) => element.Attribute("prop", prop);

        public static IElement<FormItem> Label(this IElement<FormItem> element, string label) => element.Attribute("label", label);

        public static IElement<FormItem> Label(this IElement<FormItem> element, BoundValue label) => element.Attribute("label", label);

        public static IElement<FormItem> LabelWidth(this IElement<FormItem> element, string labelWidth) => element.Attribute("label-width", labelWidth);

        public static IElement<FormItem> LabelWidth(this IElement<FormItem> element, BoundValue labelWidth) => element.Attribute("label-width", labelWidth);

        public static IElement<FormItem> Required(this IElement<FormItem> element, BoundValue<bool> required) => element.Attribute("required", required);

        public static IElement<FormItem> Rules(this IElement<FormItem> element, BoundValue rules) => element.Attribute("rules", rules);

        public static IElement<FormItem> Error(this IElement<FormItem> element, string error) => element.Attribute("error", error);

        public static IElement<FormItem> Error(this IElement<FormItem> element, BoundValue error) => element.Attribute("error", error);

        public static IElement<FormItem> ShowMessage(this IElement<FormItem> element, BoundValue<bool> showMessage) => element.Attribute("show-message", showMessage);
    }
}