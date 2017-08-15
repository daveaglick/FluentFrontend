using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FluentFrontend.Vue
{
    public class VueHelper<TModel> : FluentHelper<TModel>, IVueHelper
    {
        public VueHelper(IFluentAdapter<TModel> adapter) : base(adapter)
        {
        }

        public override KeyValuePair<string, string> GetAttribute(string name, object value)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (GetAttributeValue(value, out object attributeValue))
            {
                name = $"v-bind:{name}";
            }
            return base.GetAttribute(name, attributeValue);
        }

        private static bool GetAttributeValue(object value, out object attributeValue)
        {
            attributeValue = value;

            if (value is BoundValue boundValue)
            {
                GetAttributeValue(boundValue.Value, out attributeValue);
                return true;
            }

            if (value is bool || value is int || value is double)
            {
                attributeValue = value.ToString().ToLower();
                return true;
            }

            if (value is DateTime)
            {
                attributeValue = ((DateTime)value).ToString("s");
                return true;
            }
            
            return false;
        }
    }
}
