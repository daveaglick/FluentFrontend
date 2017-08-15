using FluentFrontend.Vue;

namespace FluentFrontend.Element
{
    public class VueElementHelper<TModel> : ElementHelper<TModel>
    {
        internal VueHelper<TModel> Vue { get; }

        public VueElementHelper(IFluentAdapter<TModel> adapter, VueHelper<TModel> vue) : base(adapter)
        {
            Vue = vue;
        }
    }
}