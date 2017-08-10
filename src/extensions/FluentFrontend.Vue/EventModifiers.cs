using System;
using System.Collections.Generic;
using System.Text;

namespace FluentFrontend.Vue
{
    [Flags]
    public enum EventModifiers
    {
        // Common
        Stop = 1 << 0,
        Prevent = 1 << 1,
        Capture = 1 << 2,
        Self = 1 << 3,
        Once = 1 << 4,

        // Key
        Enter = 1 << 5,
        Tab = 1 << 6,
        Delete = 1 << 7,
        Esc = 1 << 8,
        Space = 1 << 9,
        Up = 1 << 10,
        Down = 1 << 11,
        Left = 1 << 12,
        Right = 1 << 13,

        // Modifier Keys
        Ctrl = 1 << 14,
        Alt = 1 << 15,
        Shift = 1 << 16,
        Meta = 1 << 17,

        // Mouse
        Middle = 1 << 18
    }
}
