using System.IO;

namespace FluentFrontend.Vue
{
    public interface IInstanceTag : ITag
    {
    }

    public class Instance : Tag<VueHelper>, IInstanceTag
    {
        public static class TagDataKeys
        {
            public const string InstanceName = nameof(InstanceName);
            public const string ElementId = nameof(ElementId);
            public const string VueModel = nameof(VueModel);
        }

        internal Instance(VueHelper helper) : base(helper, "script")
        {
        }

        public override void Begin(TextWriter writer, ElementData data)
        {
            base.Begin(writer, data);

            string instanceName = (string) data.TagData[TagDataKeys.InstanceName];
            string elementId = (string)data.TagData[TagDataKeys.ElementId];
            string vueModel = GetVueModel(data);

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
            object vueModel = data.TagData[TagDataKeys.VueModel];
            if (vueModel is string vueModelScript)
            {
                return vueModelScript;
            }
            // TODO: Use JSON.NET to serialize the Vue model
            return null;
        }
    }

    public class Instance<TModel> : Instance
    {
        internal Instance(VueHelper helper) : base(helper)
        {
        }
    }

    public static class InstanceExtensions
    {
        public static IElement<Instance> Instance(this VueHelper helper, string instanceName = "vm", string elementId = "app") => 
            helper.Adapter.GetElement(new Instance(helper)).InstanceName(instanceName).ElementId(elementId);

        public static IElement<Instance<TModel>> Instance<TModel>(this VueHelper helper, string instanceName = "vm", string elementId = "app")
            where TModel : class => 
            helper.Adapter.GetElement(new Instance<TModel>(helper)).VueModel(default(TModel)).InstanceName(instanceName).ElementId(elementId);

        public static IElement<Instance<TModel>> Instance<TModel>(this VueHelper helper, TModel vueModel, string instanceName = "vm", string elementId = "app")
            where TModel : class => 
            helper.Adapter.GetElement(new Instance<TModel>(helper)).VueModel(vueModel).InstanceName(instanceName).ElementId(elementId);

        public static IElement<TInstance> InstanceName<TInstance>(this IElement<TInstance> element, string instanceName)
            where TInstance : Instance
            => element.SetTagData(Vue.Instance.TagDataKeys.InstanceName, instanceName?.Trim());

        public static IElement<TInstance> ElementId<TInstance>(this IElement<TInstance> element, string elementId)
            where TInstance : Instance =>
            element.SetTagData(Vue.Instance.TagDataKeys.ElementId, elementId?.Trim());

        public static IElement<Instance> VueModel(this IElement<Instance> element, string vueModelScript) => element.SetTagData(Vue.Instance.TagDataKeys.VueModel, vueModelScript);

        public static IElement<Instance<TModel>> VueModel<TModel>(this IElement<Instance<TModel>> element, TModel vueModel)
            where TModel : class =>
            element.SetTagData(Vue.Instance.TagDataKeys.VueModel, vueModel);
    }
}