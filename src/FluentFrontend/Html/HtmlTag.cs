using System;
using System.Collections.Generic;
using System.Text;

namespace FluentFrontend.Html
{
    public class HtmlTag : Tag<HtmlHelper>
    {
        internal HtmlTag(HtmlHelper helper, string name, bool emptyElement = false)
            : base(helper, name, emptyElement)
        {
        }
    }
}
