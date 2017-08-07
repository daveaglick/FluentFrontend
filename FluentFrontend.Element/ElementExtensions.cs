using System;
using System.Collections.Generic;
using System.Text;

namespace FluentFrontend.Element
{
    public static class ElementExtensions
    {
        public static FluentElementHelper Element(this IFluentHelper helper) => new FluentElementHelper(helper);

        public static IElement<Tooltip> Tooltip(this FluentElementHelper helper) => helper.GetElement(new Tooltip());
    }
}
