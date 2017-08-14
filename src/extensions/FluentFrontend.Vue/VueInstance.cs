using System;
using System.IO;
using Newtonsoft.Json;

namespace FluentFrontend.Vue
{
    public interface IVueInstance : ITag
    {
    }

    public class VueInstance : Tag<VueHelper>, IVueInstance
    {
        public static class TagDataKeys
        {
            public const string InstanceName = nameof(InstanceName);
            public const string ElementId = nameof(ElementId);
            public const string VueModel = nameof(VueModel);
        }

        internal VueInstance(VueHelper helper) : base(helper, "script")
        {
        }

        public override void Begin(TextWriter writer, ElementData data)
        {
            base.Begin(writer, data);

            string instanceName = (string) data.TagData[TagDataKeys.InstanceName];
            string elementId = (string)data.TagData[TagDataKeys.ElementId];
            string vueModel = GetVueModel(data);

            // Begin
            bool writeComma = false;
            if (!string.IsNullOrWhiteSpace(instanceName))
            {
                writer.Write($"var {instanceName} = ");
            }
            writer.Write("new Vue({");

            // Element ID
            if (!string.IsNullOrWhiteSpace(elementId))
            {
                WriteLine(writer, ref writeComma);
                if (!elementId.StartsWith("#"))
                {
                    elementId = "#" + elementId;
                }
                writer.Write($"el: '{elementId}'");
            }

            // Data
            if (!string.IsNullOrWhiteSpace(vueModel))
            {
                WriteLine(writer, ref writeComma);
                writer.Write($"data: {vueModel}");
            }

            // End
            writer.Write("});");
        }

        private void WriteLine(TextWriter writer, ref bool writeComma)
        {
            if (writeComma)
            {
                writer.Write(",");
            }
            writer.WriteLine();
            writeComma = true;
        }

        private string GetVueModel(ElementData data)
        {
            if (!data.TagData.TryGetValue(TagDataKeys.VueModel, out object vueModel))
            {
                return null;
            }
            if (vueModel is string vueModelScript)
            {
                return vueModelScript;
            }

            // Serialize the model to a JS literal
            if (vueModel != null)
            {
                using (StringWriter writer = new StringWriter())
                {
                    using (JsonTextWriter json = new JsonTextWriter(writer))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        json.Formatting = Formatting.Indented;
                        json.QuoteName = false;
                        serializer.Serialize(json, vueModel);
                        return writer.ToString();
                    }
                }
            }

            return null;
        }
    }

    public class VueInstance<TModel> : VueInstance
    {
        internal VueInstance(VueHelper helper) : base(helper)
        {
        }
    }

    public static class VueInstanceExtensions
    {
        // Element

        public static IElement<VueInstance> Instance(this VueHelper helper, string instanceName = "vm", string elementId = "app") => 
            helper.Adapter.GetElement(new VueInstance(helper)).InstanceName(instanceName).ElementId(elementId);

        public static IElement<VueInstance<TModel>> Instance<TModel>(this VueHelper helper, string instanceName = "vm", string elementId = "app")
            where TModel : class => 
            helper.Adapter.GetElement(new VueInstance<TModel>(helper)).VueModel(Activator.CreateInstance<TModel>()).InstanceName(instanceName).ElementId(elementId);

        public static IElement<VueInstance<TModel>> Instance<TModel>(this VueHelper helper, TModel vueModel, string instanceName = "vm", string elementId = "app")
            where TModel : class => 
            helper.Adapter.GetElement(new VueInstance<TModel>(helper)).VueModel(vueModel).InstanceName(instanceName).ElementId(elementId);

        public static IElement<VueInstance<TModel>> Instance<TModel>(this VueHelper<TModel> helper, string instanceName = "vm", string elementId = "app")
            where TModel : class =>
            helper.Adapter.GetElement(new VueInstance<TModel>(helper)).VueModel(helper.Adapter.Model ?? Activator.CreateInstance<TModel>()).InstanceName(instanceName).ElementId(elementId);

        public static IElement<VueInstance<TModel>> Instance<TModel>(this VueHelper<TModel> helper, TModel vueModel, string instanceName = "vm", string elementId = "app")
            where TModel : class =>
            helper.Adapter.GetElement(new VueInstance<TModel>(helper)).VueModel(vueModel).InstanceName(instanceName).ElementId(elementId);

        // Data

        public static IElement<TInstance> InstanceName<TInstance>(this IElement<TInstance> element, string instanceName)
            where TInstance : VueInstance
            => element.SetTagData(Vue.VueInstance.TagDataKeys.InstanceName, instanceName?.Trim());

        public static IElement<TInstance> ElementId<TInstance>(this IElement<TInstance> element, string elementId)
            where TInstance : VueInstance =>
            element.SetTagData(Vue.VueInstance.TagDataKeys.ElementId, elementId?.Trim());

        public static IElement<VueInstance> VueModel(this IElement<VueInstance> element, string vueModelScript) => element.SetTagData(Vue.VueInstance.TagDataKeys.VueModel, vueModelScript);

        public static IElement<VueInstance<TModel>> VueModel<TModel>(this IElement<VueInstance<TModel>> element, TModel vueModel)
            where TModel : class =>
            element.SetTagData(Vue.VueInstance.TagDataKeys.VueModel, vueModel);
    }
}