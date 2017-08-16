using System;
using System.Linq.Expressions;

namespace FluentFrontend
{
    /// <summary>
    /// A simple default <see cref="IModelMetadata"/>.
    /// </summary>
    /// <typeparam name="TModel">The type of model.</typeparam>
    /// <typeparam name="TProperty">The type of property.</typeparam>
    internal class ModelMetadata<TModel, TProperty> : IModelMetadata
    {
        public string PropertyName { get; }
        public string NestedPropertyName { get; }
        public string DisplayName => PropertyName;
        public string Description => string.Empty;
        public bool IsRequired => false;

        public ModelMetadata(Expression<Func<TModel, TProperty>> expression)
        {
            NestedPropertyName = ExpressionHelper.GetMemberName(expression, true);
            PropertyName = ExpressionHelper.GetMemberName(expression);
        }
    }
}