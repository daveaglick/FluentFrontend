using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public abstract class ElementTag : VueTag<ElementHelper>
    {
        protected ElementTag(ElementHelper helper, string name, bool emptyElement = false) 
            : base(helper, name, emptyElement)
        {
        }
    }
}