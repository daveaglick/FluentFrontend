using System;
using System.IO;
using System.Linq.Expressions;

namespace FluentFrontend.Tests
{
    public class TestAdapter<TModel> : IFluentAdapter<TModel>
    {
        public TextWriter Writer { get; set; }

        public TModel Model { get; set; }

        public IElement<TTag> GetElement<TTag>(TTag tag) where TTag : class, ITag
        {
            throw new NotImplementedException();
        }

        public IModelMetadata GetModelMetadata<TMetadataModel, TProperty>(Expression<Func<TMetadataModel, TProperty>> expression)
        {
            throw new NotImplementedException();
        }

        public IModelMetadata GetModelMetadata<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            throw new NotImplementedException();
        }
    }
}