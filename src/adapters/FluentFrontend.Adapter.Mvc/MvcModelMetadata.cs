using System.Web.Mvc;

namespace FluentFrontend.Adapter.Mvc
{
    public class MvcModelMetadata : IModelMetadata
    {
        private readonly ModelMetadata _metadata;

        public MvcModelMetadata(ModelMetadata metadata, string nestedPropertyName)
        {
            _metadata = metadata;
            NestedPropertyName = nestedPropertyName;
        }

        public string PropertyName => _metadata.PropertyName;

        public string NestedPropertyName { get; }

        public string DisplayName => _metadata.GetDisplayName();

        public string Description => _metadata.Description;

        public bool IsRequired => _metadata.IsRequired;
    }
}