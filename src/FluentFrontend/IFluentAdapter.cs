using System;
using System.IO;
using System.Linq.Expressions;

namespace FluentFrontend
{
    public interface IFluentAdapter
    {
        /// <summary>
        /// The <see cref="TextWriter"/> to write to by default.
        /// </summary>
        TextWriter Writer { get; }

        /// <summary>
        /// Constructs an element given a tag.
        /// </summary>
        /// <typeparam name="TTag">The type of tag to create.</typeparam>
        /// <param name="helper">The current helper class.</param>
        /// <param name="tag">An instance of the specified tag.</param>
        /// <returns>A new element.</returns>
        IElement<TTag> GetElement<TTag>(IFluentHelper helper, TTag tag) where TTag : class, ITag;
    }

    public interface IFluentAdapter<TModel> : IFluentAdapter
    {
        TModel Model { get; }

        IModelMetadata GetModelMetadata<TProperty>(Expression<Func<TModel, TProperty>> expression);
    }
}