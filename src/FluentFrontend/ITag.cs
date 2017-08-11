using System;
using System.IO;

namespace FluentFrontend
{
    /// <summary>
    /// Provides functionality specific to a particular tag and helps distinguish
    /// one element from another for writing tag-specific extension methods.
    /// Note that all implementations should be immutable (just like an <see cref="IElement"/>.
    /// If the tag needs to store state, it should do so in the special <see cref="IElement{TTag}.TagData"/>
    /// collection. Any values stored here will be available to the tag during rendering through the
    /// <see cref="ElementData"/> instance.
    /// </summary>
    public interface ITag
    {
        IFluentHelper Helper { get; }

        string Name { get; }

        bool EmptyElement { get; }

        void Begin(TextWriter writer, ElementData data);

        void End(TextWriter writer, ElementData data);
    }
}