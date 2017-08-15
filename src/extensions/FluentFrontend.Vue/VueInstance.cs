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
            public const string Data = nameof(Data);
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
            if (!data.TagData.TryGetValue(TagDataKeys.Data, out object vueModel))
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

    public static class VueInstanceExtensions
    {
        // Element

        public static IElement<VueInstance> Instance(this VueHelper helper, string instanceName = "vm", string elementId = "app") => 
            helper.Adapter.GetElement(new VueInstance(helper)).InstanceName(instanceName).ElementId(elementId);

        public static IElement<VueInstance> Instance<TModel>(this VueHelper<TModel> helper, string instanceName = "vm", string elementId = "app")
            where TModel : class =>
            helper.Adapter.GetElement(new VueInstance(helper)).InstanceName(instanceName).ElementId(elementId).Data(helper.Adapter.Model);

        // Data

        public static IElement<VueInstance> InstanceName(this IElement<VueInstance> element, string instanceName) =>
            element.SetTagData(VueInstance.TagDataKeys.InstanceName, instanceName?.Trim());

        public static IElement<VueInstance> ElementId(this IElement<VueInstance> element, string elementId) =>
            element.SetTagData(VueInstance.TagDataKeys.ElementId, elementId?.Trim());

        public static IElement<VueInstance> Data(this IElement<VueInstance> element, string dataScript) => 
            element.SetTagData(VueInstance.TagDataKeys.Data, dataScript);

        public static IElement<VueInstance> Data<TModel>(this IElement<VueInstance> element, TModel model = null)
            where TModel : class => 
            element.SetTagData(VueInstance.TagDataKeys.Data, model ?? Activator.CreateInstance<TModel>());
    }
}