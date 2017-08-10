using System;
using System.Collections.Generic;
using System.Text;

namespace FluentFrontend.Vue
{
    [Flags]
    public enum BindingModifiers
    {
        Lazy = 1 << 0,
        Number = 1 << 1,
        Trim = 1 << 2
    }
}
