using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace FluentFrontend
{
    internal class DefaultElement<TTag> : Element<TTag>
        where TTag : class, ITag
    {
        public DefaultElement(TTag tag) : base(tag)
        {
        }

        public DefaultElement(IElement<TTag> element, ElementData data) : base(element, data)
        {
        }

        protected override IElement<TTag> Clone(ElementData data) => new DefaultElement<TTag>(this, data);
    }
}
