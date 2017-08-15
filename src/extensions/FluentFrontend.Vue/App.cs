namespace FluentFrontend.Vue
{
    public class App : Tag<IVueHelper>
    {
        internal App(IVueHelper helper) : base(helper, "div")
        {
        }
    }

    public static class AppExtensions
    {
        public static IElement<App> App(this IVueHelper helper, string id = "app") => 
            helper.Adapter.GetElement(new App(helper)).Id(id);
    }
}