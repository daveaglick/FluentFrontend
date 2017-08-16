using System;
using System.IO;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace FluentFrontend.Adapter.Mvc
{
    public class FluentMvcAdapter<TModel> : FluentAdapter<TModel>
    {
        public FluentMvcAdapter(TextWriter writer, TModel model) 
            : base(writer, model)
        {
        }

        public override IElement<TTag> GetElement<TTag>(TTag tag) => new MvcElement<TTag>(tag);

        public override IModelMetadata GetModelMetadata<TProperty>(Expression<Func<TModel, TProperty>> expression) => 
            new MvcModelMetadata(
                ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<TModel>(Model)),
                ExpressionHelper.GetMemberName(expression, true));

        public override IModelMetadata GetModelMetadata<TMetadataModel, TProperty>(Expression<Func<TMetadataModel, TProperty>> expression) => 
            new MvcModelMetadata(
                ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<TMetadataModel>(default(TMetadataModel))),
                ExpressionHelper.GetMemberName(expression, true));
    }
}