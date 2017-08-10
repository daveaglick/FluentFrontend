using System;
using System.IO;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace FluentFrontend.Adapter.Mvc
{
    public class FluentMvcAdapter : FluentAdapter
    {
        public FluentMvcAdapter(TextWriter writer) : base(writer)
        {
        }

        public override IElement<TTag> GetElement<TTag>(TTag tag)
        {
            return new MvcElement<TTag>(tag);
        }
    }

    public class FluentMvcAdapter<TModel> : FluentAdapter<TModel>
    {
        public FluentMvcAdapter(TextWriter writer, TModel model) 
            : base(new FluentMvcAdapter(writer), model)
        {
        }

        public override IModelMetadata GetModelMetadata<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            return new MvcModelMetadata(ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<TModel>(Model)));
        }
    }
}