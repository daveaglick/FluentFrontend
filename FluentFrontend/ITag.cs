using System;
using System.IO;

namespace FluentFrontend
{
    public interface ITag
    {
        string Name { get; }

        bool EmptyElement { get; }

        void Begin(TextWriter writer, ElementData data);

        void End(TextWriter writer, ElementData data);
    }
}