using System;
using System.IO;
using System.Net;

namespace FluentFrontend
{
    internal class ContentElement : IElement
    {
        private readonly IFluentHelper _helper;
        private readonly string _content;
        private readonly bool _encode;

        public ContentElement(IFluentHelper helper, string content, bool encode)
        {
            _helper = helper;
            _content = content;
            _encode = encode;
        }

        /// <inheritdoc />
        public void Write() => Write(_helper.Writer);

        /// <inheritdoc />
        public void Write(TextWriter writer) => Begin(writer).Dispose();

        /// <inheritdoc />
        public IDisposable Begin() => Begin(_helper.Writer);

        /// <inheritdoc />
        public IDisposable Begin(TextWriter writer)
        {
            writer.Write(_encode ? WebUtility.HtmlEncode(_content) : _content);
            return new ActionDisposable(() => { });
        }
    }
}