using System;
using System.IO;
using System.Linq.Expressions;

namespace FluentFrontend.Tests
{
    public class TestAdapter : IFluentAdapter
    {
        public TextWriter Writer { get; }

        public IElement<TTag> GetElement<TTag>(TTag tag) where TTag : class, ITag
        {
            throw new NotImplementedException();
        }

        public IModelMetadata GetModelMetadata<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            throw new NotImplementedException();
        }
    }
}