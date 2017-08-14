using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public class Option : ElementTag
    {
        internal Option(ElementHelper helper) : base(helper, "el-option")
        {
        }
    }

    public static class OptionExtensions
    {
        // Element

        public static IElement<Option> Option(this ElementHelper helper) => helper.Adapter.GetElement(new Option(helper));

        // Attributes

        public static IElement<Option> Value(this IElement<Option> element, string value) => element.Attribute("value", value);

        public static IElement<Option> Value(this IElement<Option> element, BoundValue value) => element.Attribute("value", value);

        public static IElement<Option> Label(this IElement<Option> element, string label) => element.Attribute("label", label);

        public static IElement<Option> Label(this IElement<Option> element, BoundValue label) => element.Attribute("label", label);

        public static IElement<Option> Disabled(this IElement<Option> element, bool disabled) => element.Attribute("disabled", disabled);

        public static IElement<Option> Disabled(this IElement<Option> element, BoundValue disabled) => element.Attribute("disabled", disabled);
    }
}