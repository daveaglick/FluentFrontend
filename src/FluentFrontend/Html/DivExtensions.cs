namespace FluentFrontend.Html
{
    public static class DivExtensions
    {
        public static IElement<Div> FooBar(this IElement<Div> element) => element.Attribute("foo", "bar");
    }
}