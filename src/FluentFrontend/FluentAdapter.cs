using System;
using System.IO;
using System.Linq.Expressions;

namespace FluentFrontend
{
    public abstract class FluentAdapter<TModel> : IFluentAdapter<TModel>
    {
        public TextWriter Writer { get; }

        public TModel Model { get; }

        protected FluentAdapter(TextWriter writer, TModel model)
        {
            Writer = writer ?? throw new ArgumentNullException(nameof(writer));
            Model = model;
        }

        public virtual IElement<TTag> GetElement<TTag>(TTag tag)
            where TTag : class, ITag =>
            new DefaultElement<TTag>(tag);

        public virtual IModelMetadata GetModelMetadata<TProperty>(Expression<Func<TModel, TProperty>> expression) =>
            GetModelMetadata<TModel, TProperty>(expression);

        public virtual IModelMetadata GetModelMetadata<TMetadataModel, TProperty>(Expression<Func<TMetadataModel, TProperty>> expression) =>
            new ModelMetadata<TMetadataModel, TProperty>(expression);
    }
}