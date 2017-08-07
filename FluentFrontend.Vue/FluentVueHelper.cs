using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FluentFrontend.Vue
{
    public class FluentVueHelper : FluentLibraryHelper
    {
        public FluentVueHelper(IFluentHelper fluentHelper) : base(fluentHelper)
        {
        }

        public override KeyValuePair<string, string> GetAttribute(string name, object value)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return GetAttributeValue(value, out string attributeValue) 
                ? new KeyValuePair<string, string>($"v-bind:{name}", attributeValue) 
                : base.GetAttribute(name, value);
        }

        private static bool GetAttributeValue(object value, out string attributeValue)
        {
            attributeValue = null;

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
