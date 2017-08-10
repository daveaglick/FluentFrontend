using System;
using System.IO;
using System.Net;

namespace FluentFrontend
{
    internal class ContentElement : IElement
    {
        private readonly TextWriter _writer;
        private readonly string _content;
        private readonly bool _encode;

        public ContentElement(TextWriter writer, string content, bool encode)
        {
            _writer = writer;
            _content = content;
            _encode = encode;
        }

        /// <inheritdoc />
        public void Write() => Write(_writer);

        /// <inheritdoc />
        public void Write(TextWriter writer) => Begin(writer).Dispose();

        /// <inheritdoc />
        public IDisposable Begin() => Begin(_writer);

        /// <inheritdoc />
        public IDisposable Begin(TextWriter writer)
        {
            writer.Write(_encode ? WebUtility.HtmlEncode(_content) : _content);
            return new ActionDisposable(() => { });
        }
    }
}