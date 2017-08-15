using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public class Col : ElementTag
    {
        internal Col(IElementHelper helper) : base(helper, "el-col")
        {
        }
    }

    public static class ColExtensions
    {
        // Element

        public static IElement<Col> Col(this IElementHelper helper) => helper.Adapter.GetElement(new Col(helper));

        // Attributes

        public static IElement<Col> Gutter(this IElement<Col> element, BoundValue<int> gutter) => element.Attribute("gutter", gutter);

        public static IElement<Col> Type(this IElement<Col> element, string type) => element.Attribute("type", type);

        public static IElement<Col> Type(this IElement<Col> element, BoundValue type) => element.Attribute("type", type);

        public static IElement<Col> Justify(this IElement<Col> element, RowJustify justify) => element.Attribute("justify", justify);

        public static IElement<Col> Justify(this IElement<Col> element, BoundValue justify) => element.Attribute("justify", justify);

        public static IElement<Col> Align(this IElement<Col> element, RowAlign align) => element.Attribute("align", align);

        public static IElement<Col> Align(this IElement<Col> element, BoundValue align) => element.Attribute("align", align);

        public static IElement<Col> Tag(this IElement<Col> element, string tag) => element.Attribute("tag", tag);

        public static IElement<Col> Tag(this IElement<Col> element, BoundValue tag) => element.Attribute("tag", tag);
    }
}