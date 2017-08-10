using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace FluentFrontend
{
    public abstract class Tag<THelper> : ITag
        where THelper : FluentHelper
    {
        IFluentHelper ITag.Helper => Helper;

        public THelper Helper { get; }

        public string Name { get; }

        public bool EmptyElement { get; }

        protected Tag(THelper helper, string name, bool emptyElement = false)
        {
            Helper = helper ?? throw new ArgumentNullException(nameof(helper));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            EmptyElement = emptyElement;
        }

        public virtual void Begin(TextWriter writer, ElementData data)
        {
            IImmutableDictionary<string, string> attributes = data.Attributes;

            // Merge CSS classes
            if (data.Classes.Count > 0)
            {
                string classes = attributes.ContainsKey("class")
                    ? $"{attributes["class"]} "
                    : string.Empty;
                attributes = attributes.SetItem("class", $"{classes}{string.Join((string)" ", (IEnumerable<string>)data.Classes)}");
            }

            // Merge inline styles
            if (data.Styles.Count > 0)
            {
                string style = attributes.ContainsKey("style")
                    ? attributes["style"]
                    : string.Empty;
                if (style.Length > 0 && !style.TrimEnd().EndsWith(";"))
                {
                    style = $"{style};";
                }
                attributes = attributes.SetItem("style", $"{style}{string.Join(string.Empty, data.Styles.Select(x => x.Key + ": " + x.Value + ";"))}");
            }

            writer.Write("<");
            writer.Write(Name);
            foreach (KeyValuePair<string, string> attribute in attributes)
            {
                writer.Write(" ");
                writer.Write(attribute.Key);
                writer.Write("=\"");
                writer.Write(attribute.Value);  // TODO: escape attribute value
                writer.Write("\"");
            }
            writer.WriteLine(">");
        }

        public virtual void End(TextWriter writer, ElementData data)
        {
            if (!EmptyElement)
            {
                writer.WriteLine($"</{Name}>");
            }
        }
    }
}