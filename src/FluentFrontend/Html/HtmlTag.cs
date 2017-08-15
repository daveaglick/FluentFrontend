using System;
using System.Collections.Generic;
using System.Text;

namespace FluentFrontend.Html
{
    public class HtmlTag : Tag<IHtmlHelper>
    {
        internal HtmlTag(IHtmlHelper helper, string name, bool emptyElement = false)
            : base(helper, name, emptyElement)
        {
        }
    }
}
