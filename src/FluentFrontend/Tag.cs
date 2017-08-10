using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Net;

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
            string[] classes = data.Classes.Concat(
                attributes.ContainsKey("class")
                    ? attributes["class"].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    : (IEnumerable<string>) ImmutableList<string>.Empty)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToArray();
            if (classes.Length > 0)
            {
                attributes = attributes.SetItem("class", string.Join(" ", classes));
            }

            // Merge inline styles
            KeyValuePair<string,string>[] styles = data.Styles
                .Concat(
                    attributes.ContainsKey("style")
                        ? attributes["style"]
                            .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.Split(':'))
                            .Select(x => x.Length > 1
                                ? new KeyValuePair<string, string>(x[0], string.Join(":", x.Skip(1)))
                                : new KeyValuePair<string, string>(x[0], string.Empty))
                        : ImmutableList<KeyValuePair<string, string>>.Empty)
                        .OrderBy(x => x.Key)
                        .ToArray();
            if (data.Styles.Count > 0)
            {
                attributes = attributes.SetItem("style", string.Join(string.Empty, data.Styles.Select(x => $"{x.Key}{(x.Value == string.Empty ? string.Empty : ":")}{x.Value};")));
            }

            writer.Write("<");
            writer.Write(Name);
            foreach (KeyValuePair<string, string> attribute in attributes.OrderBy(x => x.Key))
            {
                writer.Write(" ");
                writer.Write(attribute.Key);
                writer.Write("=\"");
                writer.Write(attribute.Value);
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