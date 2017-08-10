using FluentFrontend.Html;

namespace FluentFrontend
{
    public static class AdapterExtensions
    {
        public static IElement<Tag> Tag(this IFluentAdapter adapter, string name, bool emptyElement = false) =>
            adapter.GetElement(new FluentHtmlHelper(adapter), new Tag(name, emptyElement));
    }
}