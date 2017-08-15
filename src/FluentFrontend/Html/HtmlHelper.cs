namespace FluentFrontend.Html
{
    public class HtmlHelper<TModel> : FluentHelper<TModel>, IHtmlHelper
    {
        public HtmlHelper(IFluentAdapter<TModel> adapter) : base(adapter)
        {
        }
    }
}