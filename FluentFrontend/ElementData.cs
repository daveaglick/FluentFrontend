using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace FluentFrontend
{
    public class ElementData
    {
        private readonly IFluentHelper _helper;

        internal ElementData(IFluentHelper helper)
        {
            _helper = helper;
            Attributes = ImmutableDictionary<string, string>.Empty;
            Styles = ImmutableDictionary<string, string>.Empty;
            Classes = ImmutableHashSet<string>.Empty;
        }

        private ElementData(
            ElementData data,
            IImmutableDictionary<string, string> attributes = null,
            IImmutableDictionary<string, string> styles = null,
            IImmutableSet<string> classes = null)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            _helper = data._helper;
            Attributes = attributes ?? data.Attributes;
            Styles = styles ?? data.Styles;
            Classes = classes ?? data.Classes;
        }

        public IImmutableDictionary<string, string> Attributes { get; }
        
        public IImmutableDictionary<string, string> Styles { get; }
        
        public IImmutableSet<string> Classes { get; }

        public ElementData Attribute(string name, object value)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            // TODO: validate attribute name

            if (value == null && Attributes.ContainsKey(name))
            {
                return new ElementData(this, attributes: Attributes.Remove(name));
            }
            if (value != null)
            {
                KeyValuePair<string, string> attribute = _helper.GetAttribute(name, value);
                return new ElementData(this, attributes: Attributes.SetItem(attribute.Key, attribute.Value));
            }
            return this;
        }

        public ElementData Style(string name, string value)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            // TODO: validate style name

            if (value == null && Styles.ContainsKey(name))
            {
                return new ElementData(this, styles: Styles.Remove(name));
            }
            if (value != null)
            {
                return new ElementData(this, styles: Styles.SetItem(name, value));
            }
            return this;
        }

        public ElementData Class(params string[] classes)
        {
            if (classes == null)
            {
                return this;
            }

            // TODO: validate class name

            return new ElementData(this, classes: Classes.Union(
                classes
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .SelectMany(x => x.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                    .Where(x => !string.IsNullOrWhiteSpace(x))));
        }

        public ElementData RemoveClass(params string[] classes)
        {
            if (classes == null)
            {
                return this;
            }

            return new ElementData(this, classes: Classes.Except(
                classes
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .SelectMany(x => x.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                    .Where(x => !string.IsNullOrWhiteSpace(x))));
        }
    }
}