namespace FluentFrontend.Tests
{
    public class TestTag : Tag<TestHelper>
    {
        public TestTag(string name, bool emptyElement = false)
            : base(new TestHelper(new TestAdapter()), name, emptyElement)
        {
        }
    }
}