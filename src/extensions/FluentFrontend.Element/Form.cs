using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public class Form : ElementTag
    {
        internal Form(ElementHelper helper) : base(helper, "el-form")
        {
        }
    }

    public static class FormExtensions
    {
        public static IElement<Form> Form(this ElementHelper helper) => helper.Adapter.GetElement(new Form(helper));

        public static IElement<Form> Model(this IElement<Form> element, BoundValue model) => element.Attribute("model", model);
        public static IElement<Form> Rules(this IElement<Form> element, BoundValue rules) => element.Attribute("rules", rules);
        public static IElement<Form> Inline(this IElement<Form> element, BoundValue<bool> inline) => element.Attribute("inline", inline);
        public static IElement<Form> LabelPosition(this IElement<Form> element, FormLabelPosition labelPosition) => element.Attribute("label-position", labelPosition);
        public static IElement<Form> LabelPosition(this IElement<Form> element, BoundValue labelPosition) => element.Attribute("label-position", labelPosition);
        public static IElement<Form> LabelWidth(this IElement<Form> element, string labelWidth) => element.Attribute("label-width", labelWidth);
        public static IElement<Form> LabelWidth(this IElement<Form> element, BoundValue labelWidth) => element.Attribute("label-width", labelWidth);
        public static IElement<Form> LabelSuffix(this IElement<Form> element, string labelSuffix) => element.Attribute("label-suffix", labelSuffix);
        public static IElement<Form> LabelSuffix(this IElement<Form> element, BoundValue labelSuffix) => element.Attribute("label-suffix", labelSuffix);
        public static IElement<Form> ShowMessage(this IElement<Form> element, BoundValue<bool> showMessage) => element.Attribute("show-message", showMessage);
    }

    public enum FormLabelPosition
    {
        Left,
        Right,
        Top
    }
}