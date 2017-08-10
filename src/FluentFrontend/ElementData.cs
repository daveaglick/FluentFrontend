using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace FluentFrontend
{
    public class ElementData
    {
        private readonly IFluentHelper _helper;

        public IImmutableDictionary<string, string> Attributes { get; }
        
        public IImmutableDictionary<string, string> Styles { get; }
        
        public IImmutableSet<string> Classes { get; }
        
        public IImmutableList<ElementChild> Children { get; }

        public IImmutableList<IElement> Parents { get; }

        internal ElementData(IFluentHelper helper)
        {
            _helper = helper;
            Attributes = ImmutableDictionary<string, string>.Empty;
            Styles = ImmutableDictionary<string, string>.Empty;
            Classes = ImmutableHashSet<string>.Empty;
            Children = ImmutableList<ElementChild>.Empty;
            Parents = ImmutableList<IElement>.Empty;
        }

        internal ElementData(
            ElementData data,
            IImmutableDictionary<string, string> attributes = null,
            IImmutableDictionary<string, string> styles = null,
            IImmutableSet<string> classes = null,
            IImmutableList<ElementChild> children = null,
            IImmutableList<IElement> parents = null)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            _helper = data._helper;
            Attributes = attributes ?? data.Attributes;
            Styles = styles ?? data.Styles;
            Classes = classes ?? data.Classes;
            Children = children ?? data.Children;
            Parents = parents ?? data.Parents;
        }

        public ElementData Attribute(string name, object value)
        {
            if (name == null)
            {
                return this;
            }
            
            // HTML spec requires attribute names to be lowercase
            name = name.ToLower().Trim();

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
                return this;
            }

            name = name.Trim();
            value = value.Trim();

            // Trim a trailing semicolon, it'll be inserted later
            if (value.EndsWith(";"))
            {
                value = value.Substring(0, value.Length - 1);
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
                    .Select(x => x.Trim())
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

        public ElementData Child(IElement child, ChildPosition position) => 
            child == null ? this : new ElementData(this, children: Children.Add(new ElementChild(child, position)));

        public ElementData EditChildren(Func<IImmutableList<ElementChild>, IImmutableList<ElementChild>> edit) => 
            new ElementData(this, children: edit(Children) ?? ImmutableList<ElementChild>.Empty);

        public ElementData Parent(IElement parent) =>
            parent == null ? this : new ElementData(this, parents: Parents.Add(parent));

        public ElementData EditParents(Func<IImmutableList<IElement>, IImmutableList<IElement>> edit) =>
            new ElementData(this, parents: edit(Parents) ?? ImmutableList<IElement>.Empty);
    }
}