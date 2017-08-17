using System;
using System.Collections.Generic;
using System.Text;

namespace FluentFrontend.Vue
{
    public static class VueExtensions
    {
        public static VueHelper<TModel> Vue<TModel>(this IFluentAdapter<TModel> adapter) => new VueHelper<TModel>(adapter);

        // Directives

        public static IElement<TTag> VOn<TTag>(
            this IElement<TTag> element,
            string eventName,
            string handler,
            EventModifiers? modifiers = null)
            where TTag : class, ITag
        {
            string name = $"v-on:{eventName}";
            if (modifiers != null)
            {
                foreach (Enum modifier in Enum.GetValues(modifiers.Value.GetType()))
                {
                    if (modifiers.Value.HasFlag(modifier))
                    {
                        name = $"{name}.{modifier.ToString().ToLower()}";
                    }
                }
            }
            return element.Attribute(name, handler);
        }

        public static IElement<TTag> VOnce<TTag>(this IElement<TTag> element, string value)
            where TTag : class, ITag =>
            element.Attribute("v-once", string.Empty);

        public static IElement<TTag> VIf<TTag>(this IElement<TTag> element, string value)
            where TTag : class, ITag =>
            element.Attribute("v-if", value);

        public static IElement<TTag> VIf<TTag>(this IElement<TTag> element, bool value)
            where TTag : class, ITag =>
            element.Attribute("v-if", value.ToString().ToLower());

        public static IElement<TTag> VShow<TTag>(this IElement<TTag> element, string value)
            where TTag : class, ITag =>
            element.Attribute("v-show", value);

        public static IElement<TTag> VShow<TTag>(this IElement<TTag> element, bool value)
            where TTag : class, ITag =>
            element.Attribute("v-show", value.ToString().ToLower());

        public static IElement<TTag> VFor<TTag>(this IElement<TTag> element, string data, string item = "item")
            where TTag : class, ITag =>
            element.Attribute("v-for", $"{item} in {data}");

        // Common Attributes

        public static IElement<TTag> VRef<TTag>(this IElement<TTag> element, string referenceId)
            where TTag : class, ITag =>
            element.Attribute("ref", referenceId);

        public static IElement<TTag> VModel<TTag>(
            this IElement<TTag> element,
            BoundValue value,
            BindingModifiers? modifiers = null)
            where TTag : class, ITag
        {
            string name = $"v-model";
            if (modifiers != null)
            {
                foreach (Enum modifier in Enum.GetValues(modifiers.Value.GetType()))
                {
                    if (modifiers.Value.HasFlag(modifier))
                    {
                        name = $"{name}.{modifier.ToString().ToLower()}";
                    }
                }
            }
            return element.Attribute(name, value.Value);
        }

        // Common Events

        public static IElement<TTag> VOnClick<TTag>(
            this IElement<TTag> element,
            string handler,
            EventModifiers? modifiers = null)
            where TTag : class, ITag =>
            element.VOn("click", handler, modifiers);
    }
}
