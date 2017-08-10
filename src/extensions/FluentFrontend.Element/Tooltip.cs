using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public class Tooltip : ElementTag
    {
        internal Tooltip(ElementHelper helper) : base(helper, "el-tooltip")
        {
        }
    }

    public static class TooltipExtensions
    {
        public static IElement<Tooltip> Tooltip(this ElementHelper helper) => helper.Adapter.GetElement(new Tooltip(helper));

        public static IElement<Tooltip> Effect(this IElement<Tooltip> element, TooltipEffect effect) => element.Attribute("effect", effect);
        public static IElement<Tooltip> Effect(this IElement<Tooltip> element, BoundValue effect) => element.Attribute("effect", effect);
        public static IElement<Tooltip> Content(this IElement<Tooltip> element, string content) => element.Attribute("content", content);
        public static IElement<Tooltip> Content(this IElement<Tooltip> element, BoundValue content) => element.Attribute("content", content);
        public static IElement<Tooltip> Placement(this IElement<Tooltip> element, TooltipPlacement placement) => element.Attribute("placement", placement);
        public static IElement<Tooltip> Placement(this IElement<Tooltip> element, BoundValue placement) => element.Attribute("placement", placement);
        public static IElement<Tooltip> Disabled(this IElement<Tooltip> element, BoundValue<bool> disabled) => element.Attribute("disabled", disabled);
        public static IElement<Tooltip> Offset(this IElement<Tooltip> element, BoundValue<int> offset) => element.Attribute("offest", offset);
        public static IElement<Tooltip> OpenDelay(this IElement<Tooltip> element, BoundValue<int> openDelay) => element.Attribute("open-delay", openDelay);

    }

    public enum TooltipEffect
    {
        Dark,
        Light
    }
        
    public enum TooltipPlacement
    {
        Top,
        TopStart,
        TopEnd,
        Bottom,
        BottomStart,
        BottomEnd,
        Left,
        LeftStart,
        LeftEnd,
        Right,
        RightStart,
        RightEnd
    }
}