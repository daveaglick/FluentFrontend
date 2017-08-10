using System;

namespace FluentFrontend
{
    public class ElementChild
    {
        public IElement Element { get; }
        public ChildPosition Position { get; }

        public ElementChild(IElement element, ChildPosition position)
        {
            Element = element ?? throw new ArgumentNullException(nameof(element));
            Position = position;
        }
    }
}