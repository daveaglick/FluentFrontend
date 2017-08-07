namespace FluentFrontend
{
    public static class FluentHelperExtensions
    {
        public static IElement<Tag> Tag(this IFluentHelper helper, string name, bool emptyElement = false) =>
            helper.GetElement(new Tag(name, emptyElement));
    }
}