namespace FluentFrontend.Tests
{
    public class TestTag : Tag<TestHelper<dynamic>>
    {
        public TestTag(string name, bool emptyElement = false)
            : base(new TestHelper<dynamic>(new TestAdapter<dynamic>()), name, emptyElement)
        {
        }
    }
}