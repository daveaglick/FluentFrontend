using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace FluentFrontend
{
    internal class DefaultElement<TTag> : Element<TTag>
        where TTag : class, ITag
    {
        public DefaultElement(IFluentHelper helper, TTag tag) : base(helper, tag)
        {
        }

        public DefaultElement(Element<TTag> element, ElementData data) : base(element, data)
        {
        }

        protected override IElement<TTag> Clone(ElementData data) => new DefaultElement<TTag>(this, data);
    }
}
