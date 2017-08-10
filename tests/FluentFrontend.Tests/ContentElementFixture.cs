using System.IO;
using NUnit.Framework;

namespace FluentFrontend.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self | ParallelScope.Children)]
    public class ContentElementFixture
    {
        public class WriteTests : ContentElementFixture
        {
            [Test]
            public void WritesEncodedContent()
            {
                // Given
                ContentElement element = new ContentElement(null, "<foo>", true);

                // When
                string output;
                using (StringWriter writer = new StringWriter())
                {
                    element.Write(writer);
                    output = writer.ToString();
                }

                // Then
                Assert.That(output, Is.EqualTo("&lt;foo&gt;"));
            }

            [Test]
            public void WritesUnencodedContent()
            {
                // Given
                ContentElement element = new ContentElement(null, "<foo>", false);

                // When
                string output;
                using (StringWriter writer = new StringWriter())
                {
                    element.Write(writer);
                    output = writer.ToString();
                }

                // Then
                Assert.That(output, Is.EqualTo("<foo>"));
            }
        }
    }
}