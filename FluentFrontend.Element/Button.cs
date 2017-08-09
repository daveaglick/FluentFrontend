using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public class Button : VueTag
    {
        public Button() : base("el-button")
        {
        }
    }

    public static class ButtonExtensions
    {
        public static IElement<Button> Button(this FluentElementHelper helper) => helper.GetElement(new Button());

        public static IElement<Button> Size(this IElement<Button> element, ButtonSize size) => element.Attribute("size", size);
        public static IElement<Button> Size(this IElement<Button> element, BoundValue size) => element.Attribute("size", size);
        public static IElement<Button> Type(this IElement<Button> element, ButtonType type) => element.Attribute("type", type);
        public static IElement<Button> Type(this IElement<Button> element, BoundValue type) => element.Attribute("type", type);
        public static IElement<Button> Plain(this IElement<Button> element, BoundValue<bool> plain) => element.Attribute("plain", plain);
        public static IElement<Button> Loading(this IElement<Button> element, BoundValue<bool> loading) => element.Attribute("loading", loading);
        public static IElement<Button> Disabled(this IElement<Button> element, BoundValue<bool> disabled) => element.Attribute("disabled", disabled);
        public static IElement<Button> Icon(this IElement<Button> element, string icon) => element.Attribute("icon", icon);
        public static IElement<Button> Icon(this IElement<Button> element, BoundValue icon) => element.Attribute("icon", icon);
    }

    public enum ButtonSize
    {
        Large,
        Small,
        Mini
    }

    public enum ButtonType
    {
        Primary,
        Success,
        Warning,
        Danger,
        Info,
        Text
    }
}