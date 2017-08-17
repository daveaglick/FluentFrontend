using System;
using System.Linq.Expressions;

namespace FluentFrontend.Vue
{
    public class VueInstanceBoundValue : BoundValue
    { 
        public IElement<IVueInstance> Instance { get; }
        public IModelMetadata Metadata { get; }

        public VueInstanceBoundValue(IElement<IVueInstance> instance, IModelMetadata metadata) : base(metadata?.NestedPropertyName)
        {
            Instance = instance ?? throw new ArgumentNullException(nameof(instance));
            Metadata = metadata ?? throw new ArgumentNullException(nameof(metadata));
        }
    }
}