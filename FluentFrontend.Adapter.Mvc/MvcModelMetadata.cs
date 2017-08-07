using System.Web.Mvc;

namespace FluentFrontend.Adapter.Mvc
{
    public class MvcModelMetadata : IModelMetadata
    {
        private readonly ModelMetadata _metadata;

        public MvcModelMetadata(ModelMetadata metadata)
        {
            _metadata = metadata;
        }

        public string PropertyName => _metadata.PropertyName;

        public string DisplayName => _metadata.GetDisplayName();

        public string Description => _metadata.Description;

        public bool IsRequired => _metadata.IsRequired;
    }
}