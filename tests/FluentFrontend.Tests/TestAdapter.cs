using System.IO;

namespace FluentFrontend.Tests
{
    public class TestAdapter : IFluentAdapter
    {
        public TextWriter Writer { get; }

        public IElement<TTag> GetElement<TTag>(TTag tag) where TTag : class, ITag
        {
            throw new System.NotImplementedException();
        }
    }
}