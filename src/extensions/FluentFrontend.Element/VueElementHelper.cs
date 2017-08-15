using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public class VueElementHelper : ElementHelper
    {
        internal VueHelper Vue { get; }

        public VueElementHelper(IFluentAdapter adapter, VueHelper vue) : base(adapter)
        {
            Vue = vue;
        }
    }

    public class VueElementHelper<TModel> : ElementHelper<TModel>
    {
        internal VueHelper<TModel> Vue { get; }

        public VueElementHelper(IFluentAdapter adapter, VueHelper<TModel> vue) : base(adapter)
        {
            Vue = vue;
        }
    }
}