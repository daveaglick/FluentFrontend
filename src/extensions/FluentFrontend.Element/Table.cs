using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public class Table : ElementTag
    {
        internal Table(ElementHelper helper) : base(helper, "el-table")
        {
        }
    }

    public static class TableExtensions
    {
        // Element

        public static IElement<Table> Table(this ElementHelper helper) => helper.Adapter.GetElement(new Table(helper));

        // Attributes

        public static IElement<Table> Data(this IElement<Table> element, BoundValue data) => element.Attribute("data", data);

        public static IElement<Table> Height(this IElement<Table> element, string height) => element.Attribute("height", height);

        public static IElement<Table> Height(this IElement<Table> element, BoundValue<int> height) => element.Attribute("height", height);

        public static IElement<Table> MaxHeight(this IElement<Table> element, string maxHeight) => element.Attribute("max-height", maxHeight);

        public static IElement<Table> MaxHeight(this IElement<Table> element, BoundValue<int> maxHeight) => element.Attribute("max-height", maxHeight);

        public static IElement<Table> Stripe(this IElement<Table> element, BoundValue<bool> stripe) => element.Attribute("stripe", stripe);

        public static IElement<Table> Border(this IElement<Table> element, BoundValue<bool> border) => element.Attribute("border", border);

        public static IElement<Table> Fit(this IElement<Table> element, BoundValue<bool> fit) => element.Attribute("fit", fit);

        public static IElement<Table> ShowHeader(this IElement<Table> element, BoundValue<bool> showHeader) => element.Attribute("show-header", showHeader);

        public static IElement<Table> HighlightCurrentRow(this IElement<Table> element, BoundValue<bool> highlightCurrentRow) => element.Attribute("highlight-current-row", highlightCurrentRow);

        public static IElement<Table> CurrentRowKey(this IElement<Table> element, string currentRowKey) => element.Attribute("current-row-key", currentRowKey);

        public static IElement<Table> CurrentRowKey(this IElement<Table> element, BoundValue<int> currentRowKey) => element.Attribute("current-row-key", currentRowKey);

        public static IElement<Table> RowClassName(this IElement<Table> element, string rowClassName) => element.Attribute("row-class-name", rowClassName);

        public static IElement<Table> RowClassName(this IElement<Table> element, BoundValue rowClassName) => element.Attribute("row-class-name", rowClassName);

        public static IElement<Table> RowStyle(this IElement<Table> element, string rowStyle) => element.Attribute("row-style", rowStyle);

        public static IElement<Table> RowStyle(this IElement<Table> element, BoundValue rowStyle) => element.Attribute("row-style", rowStyle);

        public static IElement<Table> RowKey(this IElement<Table> element, string rowKey) => element.Attribute("row-key", rowKey);

        public static IElement<Table> RowKey(this IElement<Table> element, BoundValue rowKey) => element.Attribute("row-key", rowKey);

        public static IElement<Table> EmptyText(this IElement<Table> element, string emptyText) => element.Attribute("empty-text", emptyText);

        public static IElement<Table> EmptyText(this IElement<Table> element, BoundValue emptyText) => element.Attribute("empty-text", emptyText);

        public static IElement<Table> DefaultExpandAll(this IElement<Table> element, BoundValue<bool> defaultExpandAll) => element.Attribute("default-expand-all", defaultExpandAll);

        public static IElement<Table> ExpandRowKeys(this IElement<Table> element, BoundValue expandRowKeys) => element.Attribute("expand-row-keys", expandRowKeys);

        public static IElement<Table> DefaultSort(this IElement<Table> element, BoundValue defaultSort) => element.Attribute("default-sort", defaultSort);

        public static IElement<Table> TooltipEffect(this IElement<Table> element, TooltipEffect tooltipEffect) => element.Attribute("tooltip-effect", tooltipEffect);

        public static IElement<Table> TooltipEffect(this IElement<Table> element, BoundValue tooltipEffect) => element.Attribute("tooltip-effect", tooltipEffect);

        public static IElement<Table> ShowSummary(this IElement<Table> element, BoundValue<bool> showSummary) => element.Attribute("show-summary", showSummary);

        public static IElement<Table> SumText(this IElement<Table> element, string sumText) => element.Attribute("sum-text", sumText);

        public static IElement<Table> SumText(this IElement<Table> element, BoundValue sumText) => element.Attribute("sum-text", sumText);

        public static IElement<Table> SummaryMethod(this IElement<Table> element, BoundValue summaryMethod) => element.Attribute("summary-method", summaryMethod);

        // Events

        public static IElement<Table> OnSelect(this IElement<Table> element, string handler, EventModifiers? modifiers = null) => element.On("select", handler, modifiers);

        public static IElement<Table> OnSelectAll(this IElement<Table> element, string handler, EventModifiers? modifiers = null) => element.On("select-all", handler, modifiers);

        public static IElement<Table> OnSelectionChange(this IElement<Table> element, string handler, EventModifiers? modifiers = null) => element.On("selection-change", handler, modifiers);

        public static IElement<Table> OnCellMouseEnter(this IElement<Table> element, string handler, EventModifiers? modifiers = null) => element.On("cell-mouse-enter", handler, modifiers);

        public static IElement<Table> OnCellMouseLeave(this IElement<Table> element, string handler, EventModifiers? modifiers = null) => element.On("cell-mouse-leave", handler, modifiers);

        public static IElement<Table> OnCellClick(this IElement<Table> element, string handler, EventModifiers? modifiers = null) => element.On("cell-click", handler, modifiers);

        public static IElement<Table> OnCellDoubleClick(this IElement<Table> element, string handler, EventModifiers? modifiers = null) => element.On("cell-dblclick", handler, modifiers);

        public static IElement<Table> OnRowClick(this IElement<Table> element, string handler, EventModifiers? modifiers = null) => element.On("row-click", handler, modifiers);

        public static IElement<Table> OnRowContextMenu(this IElement<Table> element, string handler, EventModifiers? modifiers = null) => element.On("row-contextmenu", handler, modifiers);

        public static IElement<Table> OnRowDoubleClick(this IElement<Table> element, string handler, EventModifiers? modifiers = null) => element.On("row-dblclick", handler, modifiers);

        public static IElement<Table> OnHeaderClick(this IElement<Table> element, string handler, EventModifiers? modifiers = null) => element.On("header-click", handler, modifiers);

        public static IElement<Table> OnSortChange(this IElement<Table> element, string handler, EventModifiers? modifiers = null) => element.On("sort-change", handler, modifiers);

        public static IElement<Table> OnFilterChange(this IElement<Table> element, string handler, EventModifiers? modifiers = null) => element.On("filter-change", handler, modifiers);

        public static IElement<Table> OnCurrentChange(this IElement<Table> element, string handler, EventModifiers? modifiers = null) => element.On("current-change", handler, modifiers);

        public static IElement<Table> OnHeaderDragEnd(this IElement<Table> element, string handler, EventModifiers? modifiers = null) => element.On("header-dragend", handler, modifiers);

        public static IElement<Table> OnExpand(this IElement<Table> element, string handler, EventModifiers? modifiers = null) => element.On("expand", handler, modifiers);
    }
}