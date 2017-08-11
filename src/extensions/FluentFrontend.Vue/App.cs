namespace FluentFrontend.Vue
{
    public class App : Tag<VueHelper>
    {
        internal App(VueHelper helper) : base(helper, "div")
        {
        }
    }

    public static class AppExtensions
    {
        public static IElement<App> App(this VueHelper helper, string id = "app") => 
            helper.Adapter.GetElement(new App(helper)).Id(id);
    }
}