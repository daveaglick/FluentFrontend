namespace FluentFrontend.Vue
{
    public interface IVueTag : ITag
    {
    }

    public abstract class VueTag<THelper> : Tag<THelper>, IVueTag
        where THelper : VueHelper
    {
        protected VueTag(THelper helper, string name, bool emptyElement = false) 
            : base(helper, name, emptyElement)
        {
        }
    }
}