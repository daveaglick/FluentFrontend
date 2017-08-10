using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public class TableColumn : ElementTag
    {
        internal TableColumn(ElementHelper helper) : base(helper, "el-table-column")
        {
        }
    }

    public static class TableColumnExtensions
    {
        public static IElement<TableColumn> TableColumn(this ElementHelper helper) => helper.Adapter.GetElement(new TableColumn(helper));

        public static IElement<TableColumn> Type(this IElement<TableColumn> element, TableColumnType type) => element.Attribute("type", type);
        public static IElement<TableColumn> Type(this IElement<TableColumn> element, BoundValue type) => element.Attribute("type", type);
        public static IElement<TableColumn> Label(this IElement<TableColumn> element, string label) => element.Attribute("label", label);
        public static IElement<TableColumn> Label(this IElement<TableColumn> element, BoundValue label) => element.Attribute("label", label);
        public static IElement<TableColumn> ColumnKey(this IElement<TableColumn> element, string columnKey) => element.Attribute("column-key", columnKey);
        public static IElement<TableColumn> ColumnKey(this IElement<TableColumn> element, BoundValue columnKey) => element.Attribute("column-key", columnKey);
        public static IElement<TableColumn> Prop(this IElement<TableColumn> element, string prop) => element.Attribute("prop", prop);
        public static IElement<TableColumn> Prop(this IElement<TableColumn> element, BoundValue prop) => element.Attribute("prop", prop);
        public static IElement<TableColumn> Width(this IElement<TableColumn> element, string width) => element.Attribute("width", width);
        public static IElement<TableColumn> Width(this IElement<TableColumn> element, BoundValue width) => element.Attribute("width", width);
        public static IElement<TableColumn> MinWidth(this IElement<TableColumn> element, string minWidth) => element.Attribute("min-width", minWidth);
        public static IElement<TableColumn> MinWidth(this IElement<TableColumn> element, BoundValue minWidth) => element.Attribute("min-width", minWidth);
        public static IElement<TableColumn> Fixed(this IElement<TableColumn> element, TableColumnFixed @fixed) => element.Attribute("fixed", @fixed);
        public static IElement<TableColumn> Fixed(this IElement<TableColumn> element, BoundValue @fixed) => element.Attribute("fixed", @fixed);
        public static IElement<TableColumn> RenderHeader(this IElement<TableColumn> element, BoundValue renderHeader) => element.Attribute("render-header", renderHeader);
        public static IElement<TableColumn> Sortable(this IElement<TableColumn> element, TableColumnSortable sortable) => element.Attribute("sortable", sortable);
        public static IElement<TableColumn> Sortable(this IElement<TableColumn> element, BoundValue sortable) => element.Attribute("sortable", sortable);
        public static IElement<TableColumn> SortMethod(this IElement<TableColumn> element, BoundValue sortMethod) => element.Attribute("sort-method", sortMethod);
        public static IElement<TableColumn> Resizable(this IElement<TableColumn> element, BoundValue<bool> resizable) => element.Attribute("resizable", resizable);
        public static IElement<TableColumn> Formatter(this IElement<TableColumn> element, BoundValue formatter) => element.Attribute("formatter", formatter);
        public static IElement<TableColumn> ShowOverflowTooltip(this IElement<TableColumn> element, BoundValue<bool> showOverflowTooltip) => element.Attribute("show-overflow-tooltip", showOverflowTooltip);
        public static IElement<TableColumn> Align(this IElement<TableColumn> element, TableColumnAlign align) => element.Attribute("align", align);
        public static IElement<TableColumn> Align(this IElement<TableColumn> element, BoundValue align) => element.Attribute("align", align);
        public static IElement<TableColumn> HeaderAlign(this IElement<TableColumn> element, TableColumnHeaderAlign headerAlign) => element.Attribute("header-align", headerAlign);
        public static IElement<TableColumn> HeaderAlign(this IElement<TableColumn> element, BoundValue headerAlign) => element.Attribute("header-align", headerAlign);
        public static IElement<TableColumn> ClassName(this IElement<TableColumn> element, string className) => element.Attribute("class-name", className);
        public static IElement<TableColumn> ClassName(this IElement<TableColumn> element, BoundValue className) => element.Attribute("class-name", className);
        public static IElement<TableColumn> LabelClassName(this IElement<TableColumn> element, string labelClassName) => element.Attribute("label-class-name", labelClassName);
        public static IElement<TableColumn> LabelClassName(this IElement<TableColumn> element, BoundValue labelClassName) => element.Attribute("label-class-name", labelClassName);
        public static IElement<TableColumn> Selectable(this IElement<TableColumn> element, BoundValue selectable) => element.Attribute("selectable", selectable);
        public static IElement<TableColumn> ReserveSelection(this IElement<TableColumn> element, BoundValue<bool> reserveSelection) => element.Attribute("reserve-selection", reserveSelection);
        public static IElement<TableColumn> Filters(this IElement<TableColumn> element, BoundValue filters) => element.Attribute("filters", filters);
        public static IElement<TableColumn> FilterPlacement(this IElement<TableColumn> element, TableColumnFilterPlacement filterPlacement) => element.Attribute("filter-placement", filterPlacement);
        public static IElement<TableColumn> FilterPlacement(this IElement<TableColumn> element, BoundValue filterPlacement) => element.Attribute("filter-placement", filterPlacement);
        public static IElement<TableColumn> FilterMultiple(this IElement<TableColumn> element, BoundValue<bool> filterMultiple) => element.Attribute("filter-multiple", filterMultiple);
        public static IElement<TableColumn> FilterMethod(this IElement<TableColumn> element, BoundValue filterMethod) => element.Attribute("filter-method", filterMethod);
        public static IElement<TableColumn> FilteredValue(this IElement<TableColumn> element, BoundValue filteredValue) => element.Attribute("filtered-value", filteredValue);
    }

    public enum TableColumnAlign
    {
        Left,
        Center,
        Right
    }

    public enum TableColumnFilterPlacement
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

    public enum TableColumnFixed
    {
        Left,
        Right
    }

    public enum TableColumnHeaderAlign
    {
        Left,
        Center,
        Right
    }

    public enum TableColumnSortable
    {
        True,
        False,
        Custom
    }

    public enum TableColumnType
    {
        Selection,
        Index,
        Expand
    }
}