using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public abstract class ElementTag : Tag<IElementHelper>, IVueTag
    {
        protected ElementTag(IElementHelper helper, string name, bool emptyElement = false) 
            : base(helper, name, emptyElement)
        {
        }
    }
}