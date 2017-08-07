using System;
using System.IO;
using System.Linq.Expressions;

namespace FluentFrontend
{
    public abstract class FluentAdapter : IFluentAdapter
    {
        public TextWriter Writer { get; }

        protected FluentAdapter(TextWriter writer)
        {
            Writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        public virtual IElement<TTag> GetElement<TTag>(IFluentHelper helper, TTag tag) 
            where TTag : class, ITag => 
            new DefaultElement<TTag>(helper, tag);
    }

    /// <summary>
    /// This class wraps an adapter implementation to add a strongly-typed model.
    /// </summary>
    /// <typeparam name="TModel">The model type.</typeparam>
    public abstract class FluentAdapter<TModel> : IFluentAdapter<TModel>
    {
        private readonly IFluentAdapter _adapter;

        protected FluentAdapter(IFluentAdapter adapter, TModel model)
        {
            _adapter = adapter ?? throw new ArgumentNullException(nameof(adapter));
            Model = model;
        }

        public TModel Model { get; }

        public abstract IModelMetadata GetModelMetadata<TProperty>(Expression<Func<TModel, TProperty>> expression);

        public TextWriter Writer => _adapter.Writer;

        public IElement<TTag> GetElement<TTag>(IFluentHelper helper, TTag tag)
            where TTag : class, ITag =>
            _adapter.GetElement(helper, tag);

    }
}