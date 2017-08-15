using System.Collections.Generic;

namespace FluentFrontend.Tests
{
    public class TestHelper<TModel> : FluentHelper<TModel>
    {
        public TestHelper(IFluentAdapter<TModel> adapter) : base(adapter)
        {
        }
    }
}