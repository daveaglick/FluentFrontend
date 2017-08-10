using System;
using System.IO;
using NUnit.Framework;

namespace FluentFrontend.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self | ParallelScope.Children)]
    public class TagFixture
    {
        public class WriteTests : TagFixture
        {
            [Test]
            public void OpeningTag()
            {
                // Given
                TestTag tag = new TestTag("div");
                ElementData data = new ElementData(tag.Helper);

                // When
                string output = Begin(tag, data);

                // Then
                Assert.That(output, Is.EqualTo("<div>" + Environment.NewLine));
            }

            [Test]
            public void ClosingTag()
            {
                // Given
                TestTag tag = new TestTag("div");
                ElementData data = new ElementData(tag.Helper);

                // When
                string output;
                using (StringWriter writer = new StringWriter())
                {
                    tag.End(writer, data);
                    output = writer.ToString();
                }

                // Then
                Assert.That(output, Is.EqualTo("</div>" + Environment.NewLine));
            }

            [Test]
            public void NoClosingTagIfEmptyElement()
            {
                // Given
                TestTag tag = new TestTag("div", true);
                ElementData data = new ElementData(tag.Helper);

                // When
                string output;
                using (StringWriter writer = new StringWriter())
                {
                    tag.End(writer, data);
                    output = writer.ToString();
                }

                // Then
                Assert.That(output, Is.Empty);
            }

            [Test]
            public void Attribute()
            {
                // Given
                TestTag tag = new TestTag("div");
                ElementData data = new ElementData(tag.Helper)
                    .Attribute("foo", "bar");

                // When
                string output = Begin(tag, data);

                // Then
                Assert.That(output, Is.EqualTo("<div foo=\"bar\">" + Environment.NewLine));
            }

            [Test]
            public void AttributeEncodesQuotes()
            {
                // Given
                TestTag tag = new TestTag("div");
                ElementData data = new ElementData(tag.Helper)
                    .Attribute("foo", "b\"ar");

                // When
                string output = Begin(tag, data);

                // Then
                Assert.That(output, Is.EqualTo("<div foo=\"b&quot;ar\">" + Environment.NewLine));
            }

            [Test]
            public void MultipleAttributes()
            {
                // Given
                TestTag tag = new TestTag("div");
                ElementData data = new ElementData(tag.Helper)
                    .Attribute("foo", "bar")
                    .Attribute("fizz", "buzz");

                // When
                string output = Begin(tag, data);

                // Then
                Assert.That(output, Is.EqualTo("<div fizz=\"buzz\" foo=\"bar\">" + Environment.NewLine));
            }

            [Test]
            public void SingleClass()
            {
                // Given
                TestTag tag = new TestTag("div");
                ElementData data = new ElementData(tag.Helper)
                    .Class("foo");

                // When
                string output = Begin(tag, data);

                // Then
                Assert.That(output, Is.EqualTo("<div class=\"foo\">" + Environment.NewLine));
            }

            [Test]
            public void MultipleClasses()
            {
                // Given
                TestTag tag = new TestTag("div");
                ElementData data = new ElementData(tag.Helper)
                    .Class("foo", "bar");

                // When
                string output = Begin(tag, data);

                // Then
                Assert.That(output, Is.EqualTo("<div class=\"bar foo\">" + Environment.NewLine));
            }

            [Test]
            public void MergeClasses()
            {
                // Given
                TestTag tag = new TestTag("div");
                ElementData data = new ElementData(tag.Helper)
                    .Class("foo", "bar")
                    .Attribute("class", "fizz buzz bar");

                // When
                string output = Begin(tag, data);

                // Then
                Assert.That(output, Is.EqualTo("<div class=\"bar buzz fizz foo\">" + Environment.NewLine));
            }

            [Test]
            public void DuplicateClass()
            {
                // Given
                TestTag tag = new TestTag("div");
                ElementData data = new ElementData(tag.Helper)
                    .Class("foo", "bar", "foo");

                // When
                string output = Begin(tag, data);

                // Then
                Assert.That(output, Is.EqualTo("<div class=\"bar foo\">" + Environment.NewLine));
            }

            [Test]
            public void Style()
            {
                // Given
                TestTag tag = new TestTag("div");
                ElementData data = new ElementData(tag.Helper)
                    .Style("foo", "bar");

                // When
                string output = Begin(tag, data);

                // Then
                Assert.That(output, Is.EqualTo("<div style=\"foo:bar;\">" + Environment.NewLine));
            }

            [Test]
            public void StyleEndWithSemicolon()
            {
                // Given
                TestTag tag = new TestTag("div");
                ElementData data = new ElementData(tag.Helper)
                    .Style("foo", "bar;");

                // When
                string output = Begin(tag, data);

                // Then
                Assert.That(output, Is.EqualTo("<div style=\"foo:bar;\">" + Environment.NewLine));
            }

            [Test]
            public void MultipleStyles()
            {
                // Given
                TestTag tag = new TestTag("div");
                ElementData data = new ElementData(tag.Helper)
                    .Style("foo", "bar")
                    .Style("fizz", "buzz");

                // When
                string output = Begin(tag, data);

                // Then
                Assert.That(output, Is.EqualTo("<div style=\"fizz:buzz;foo:bar;\">" + Environment.NewLine));
            }

            [Test]
            public void StylesAndClasses()
            {
                // Given
                TestTag tag = new TestTag("div");
                ElementData data = new ElementData(tag.Helper)
                    .Style("a", "b")
                    .Style("c", "d")
                    .Class("foo")
                    .Class("bar");

                // When
                string output = Begin(tag, data);

                // Then
                Assert.That(output, Is.EqualTo("<div class=\"bar foo\" style=\"a:b;c:d;\">" + Environment.NewLine));
            }

            private string Begin(TestTag tag, ElementData data)
            {
                using (StringWriter writer = new StringWriter())
                {
                    tag.Begin(writer, data);
                    return writer.ToString();
                }
            }
        }
    }
}