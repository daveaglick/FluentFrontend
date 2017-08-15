using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public class Row : ElementTag
    {
        internal Row(IElementHelper helper) : base(helper, "el-row")
        {
        }
    }

    public static class RowExtensions
    {
        // Element

        public static IElement<Row> Row(this IElementHelper helper) => helper.Adapter.GetElement(new Row(helper));

        // Attributes

        public static IElement<Row> Gutter(this IElement<Row> element, BoundValue<int> gutter) => element.Attribute("gutter", gutter);

        public static IElement<Row> Type(this IElement<Row> element, string type) => element.Attribute("type", type);

        public static IElement<Row> Type(this IElement<Row> element, BoundValue type) => element.Attribute("type", type);

        public static IElement<Row> Justify(this IElement<Row> element, RowJustify justify) => element.Attribute("justify", justify);

        public static IElement<Row> Justify(this IElement<Row> element, BoundValue justify) => element.Attribute("justify", justify);

        public static IElement<Row> Align(this IElement<Row> element, RowAlign align) => element.Attribute("align", align);

        public static IElement<Row> Align(this IElement<Row> element, BoundValue align) => element.Attribute("align", align);

        public static IElement<Row> Tag(this IElement<Row> element, string tag) => element.Attribute("tag", tag);

        public static IElement<Row> Tag(this IElement<Row> element, BoundValue tag) => element.Attribute("tag", tag);
    }

    public enum RowAlign
    {
        Top,
        Middle,
        Bottom
    }

    public enum RowJustify
    {
        Start,
        End,
        Center,
        SpaceAround,
        SpaceBetween
    }
}