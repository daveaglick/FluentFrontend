using System;
using System.IO;
using NUnit.Framework;
using Shouldly;

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
                output.ShouldBe("<div>" + Environment.NewLine);
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
                output.ShouldBe("</div>" + Environment.NewLine);
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
                output.ShouldBeEmpty();
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
                output.ShouldBe("<div foo=\"bar\">" + Environment.NewLine);
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
                output.ShouldBe("<div foo=\"b&quot;ar\">" + Environment.NewLine);
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
                output.ShouldBe("<div fizz=\"buzz\" foo=\"bar\">" + Environment.NewLine);
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
                output.ShouldBe("<div class=\"foo\">" + Environment.NewLine);
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
                output.ShouldBe("<div class=\"bar foo\">" + Environment.NewLine);
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
                output.ShouldBe("<div class=\"bar buzz fizz foo\">" + Environment.NewLine);
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
                output.ShouldBe("<div class=\"bar foo\">" + Environment.NewLine);
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
                output.ShouldBe("<div style=\"foo:bar;\">" + Environment.NewLine);
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
                output.ShouldBe("<div style=\"foo:bar;\">" + Environment.NewLine);
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
                output.ShouldBe("<div style=\"fizz:buzz;foo:bar;\">" + Environment.NewLine);
            }

            [Test]
            public void MixedStyles()
            {
                // Given
                TestTag tag = new TestTag("div");
                ElementData data = new ElementData(tag.Helper)
                    .Attribute("style", "foo: bar")
                    .Style("fizz", "buzz");

                // When
                string output = Begin(tag, data);

                // Then
                output.ShouldBe("<div style=\"foo: bar;fizz:buzz;\">" + Environment.NewLine);
            }

            [Test]
            public void MixedStylesWithSemicolon()
            {
                // Given
                TestTag tag = new TestTag("div");
                ElementData data = new ElementData(tag.Helper)
                    .Attribute("style", "foo: bar;")
                    .Style("fizz", "buzz");

                // When
                string output = Begin(tag, data);

                // Then
                output.ShouldBe("<div style=\"foo: bar;fizz:buzz;\">" + Environment.NewLine);
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
                output.ShouldBe("<div class=\"bar foo\" style=\"a:b;c:d;\">" + Environment.NewLine);
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