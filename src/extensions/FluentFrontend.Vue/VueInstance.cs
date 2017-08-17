using System;
using System.IO;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace FluentFrontend.Vue
{
    public interface IVueInstance : ITag
    {
    }

    public class VueInstance<TData> : Tag<IVueHelper>, IVueInstance
    {
        public const string InstanceNameKey = nameof(InstanceNameKey);
        public const string ElementIdKey = nameof(ElementIdKey);
        public const string DataKey = nameof(DataKey);

        internal VueInstance(IVueHelper helper) : base(helper, "script")
        {
        }

        public override void Begin(TextWriter writer, ElementData data)
        {
            base.Begin(writer, data);

            string instanceName = (string) data.TagData[InstanceNameKey];
            string elementId = (string)data.TagData[ElementIdKey];
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
            if (!data.TagData.TryGetValue(DataKey, out object vueModel))
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
        
        public static IElement<VueInstance<TModel>> Instance<TModel>(
            this VueHelper<TModel> helper, string instanceName = "vm", string elementId = "app")
            where TModel : class =>
            helper.Adapter.GetElement(new VueInstance<TModel>(helper))
                .InstanceName(instanceName).ElementId(elementId).Data(helper.Adapter.Model);

        public static IElement<VueInstance<TData>> Instance<TData>(
            this IVueHelper helper, TData model, string instanceName = "vm", string elementId = "app")
            where TData : class =>
            helper.Adapter.GetElement(new VueInstance<TData>(helper))
                .InstanceName(instanceName).ElementId(elementId).Data(model);

        // Data

        public static IElement<VueInstance<TData>> InstanceName<TData>(this IElement<VueInstance<TData>> element, string instanceName) =>
            element.SetTagData(VueInstance<TData>.InstanceNameKey, instanceName?.Trim());

        public static IElement<VueInstance<TData>> ElementId<TData>(this IElement<VueInstance<TData>> element, string elementId) =>
            element.SetTagData(VueInstance<TData>.ElementIdKey, elementId?.Trim());

        public static IElement<VueInstance<TData>> Data<TData>(this IElement<VueInstance<TData>> element, string dataScript) => 
            element.SetTagData(VueInstance<TData>.DataKey, dataScript);

        public static IElement<VueInstance<TData>> Data<TData>(this IElement<VueInstance<TData>> element, TData model = null)
            where TData : class => 
            element.SetTagData(VueInstance<TData>.DataKey, model ?? Activator.CreateInstance<TData>());

        public static string Data<TData, TProperty>(this IElement<VueInstance<TData>> element, Expression<Func<TData, TProperty>> expression) => 
            ExpressionHelper.GetMemberName(expression, true);

        public static BoundValue Bind<TData, TProperty>(this IElement<VueInstance<TData>> element, Expression<Func<TData, TProperty>> expression) => 
            new VueInstanceBoundValue(element, element.Tag.Helper.Adapter.GetModelMetadata(expression));
    }
}