using System;
using System.Collections.Generic;
using System.Text;

namespace FluentFrontend.Vue
{
    public static class VueExtensions
    {
        public static FluentVueHelper Vue(this IFluentAdapter adapter) => new FluentVueHelper(adapter);

        // Directives

        public static IElement<TTag> On<TTag>(
            this IElement<TTag> element,
            string eventName,
            string handler,
            EventModifiers? modifiers = null)
            where TTag : VueTag
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

        public static IElement<TTag> If<TTag>(this IElement<TTag> element, string value)
            where TTag : VueTag =>
            element.Attribute("v-if", value);

        public static IElement<TTag> If<TTag>(this IElement<TTag> element, bool value)
            where TTag : VueTag =>
            element.Attribute("v-if", value.ToString().ToLower());

        public static IElement<TTag> Show<TTag>(this IElement<TTag> element, string value)
            where TTag : VueTag =>
            element.Attribute("v-show", value);

        public static IElement<TTag> Show<TTag>(this IElement<TTag> element, bool value)
            where TTag : VueTag =>
            element.Attribute("v-show", value.ToString().ToLower());

        public static IElement<TTag> For<TTag>(this IElement<TTag> element, string data, string item = "item")
            where TTag : VueTag =>
            element.Attribute("v-for", $"{item} in {data}");

        // Common Attributes

        public static IElement<TTag> Ref<TTag>(this IElement<TTag> element, string referenceId)
            where TTag : VueTag =>
            element.Attribute("ref", referenceId);

        public static IElement<TTag> Model<TTag>(
            this IElement<TTag> element,
            string model,
            BindingModifiers? modifiers)
            where TTag : VueTag
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
            return element.Attribute(name, model);
        }

        // Common Events

        public static IElement<TTag> OnClick<TTag>(
            this IElement<TTag> element,
            string handler,
            EventModifiers? modifiers = null)
            where TTag : VueTag =>
            element.On("click", handler, modifiers);
    }
}
