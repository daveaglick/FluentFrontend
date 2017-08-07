using System.IO;

namespace FluentFrontend.Adapter.Mvc
{
    public class FluentMvcHelper : FluentHelper
    {
        public FluentMvcHelper(TextWriter writer) : base(writer)
        {
        }

        public override IElement<TTag> GetElement<TTag>(TTag tag)
        {
            return new MvcElement<TTag>(this, tag);
        }
    }
}