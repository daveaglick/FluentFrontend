using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using NUnit.Framework;
using FluentFrontend;
using Shouldly;

namespace FluentFrontend.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self | ParallelScope.Children)]
    public class ExpressionHelperFixture
    {
        public class TestClass
        {
            public int ValueProp { get; set; }
            public int ValueMethod() => 0;
            public object ReferenceProp { get; set; }
            public object ReferenceMethod() => null;
            public object ParamMethod(int x, object y) => null;
            public void VoidMethod() { }
            public TestClass Nested { get; set; }
        }

        public class GetMemberNameTests : ExpressionHelperFixture
        {
            [Test]
            public void ReturnsMemberNameForValueType()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.ValueProp);

                // Then
                name.ShouldBe(nameof(TestClass.ValueProp));
            }

            [Test]
            public void ReturnsMemberNameForReferenceType()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.ReferenceProp);

                // Then
                name.ShouldBe(nameof(TestClass.ReferenceProp));
            }

            [Test]
            public void ReturnsMemberNameForValueMethod()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.ValueMethod());

                // Then
                name.ShouldBe(nameof(TestClass.ValueMethod));
            }

            [Test]
            public void ReturnsMemberNameForRefefrenceMethod()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.ReferenceMethod());

                // Then
                name.ShouldBe(nameof(TestClass.ReferenceMethod));
            }

            [Test]
            public void ReturnsMemberNameForMethodWithParameters()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.ParamMethod(default(int), default(object)));

                // Then
                name.ShouldBe(nameof(TestClass.ParamMethod));
            }

            [Test]
            public void ReturnsMemberNameForVoidMethod()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.VoidMethod());

                // Then
                name.ShouldBe(nameof(TestClass.VoidMethod));
            }

            [Test]
            public void ReturnsNestedMemberNameForValueType()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.Nested.ValueProp, true);

                // Then
                name.ShouldBe($"{nameof(TestClass.Nested)}.{nameof(TestClass.ValueProp)}");
            }

            [Test]
            public void ReturnsTwoLevelNestedMemberNameForValueType()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.Nested.Nested.ValueProp, true);

                // Then
                name.ShouldBe($"{nameof(TestClass.Nested)}.{nameof(TestClass.Nested)}.{nameof(TestClass.ValueProp)}");
            }

            [Test]
            public void ReturnsNestedMemberNameForReferenceType()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.Nested.ReferenceProp, true);

                // Then
                name.ShouldBe($"{nameof(TestClass.Nested)}.{nameof(TestClass.ReferenceProp)}");
            }

            [Test]
            public void ReturnsTwoLevelNestedMemberNameForReferenceType()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.Nested.Nested.ReferenceProp, true);

                // Then
                name.ShouldBe($"{nameof(TestClass.Nested)}.{nameof(TestClass.Nested)}.{nameof(TestClass.ReferenceProp)}");
            }

            [Test]
            public void ReturnsNestedMemberNameForValueMethod()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.Nested.ValueMethod(), true);

                // Then
                name.ShouldBe($"{nameof(TestClass.Nested)}.{nameof(TestClass.ValueMethod)}");
            }

            [Test]
            public void ReturnsTwoLevelNestedMemberNameForValueMethod()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.Nested.Nested.ValueMethod(), true);

                // Then
                name.ShouldBe($"{nameof(TestClass.Nested)}.{nameof(TestClass.Nested)}.{nameof(TestClass.ValueMethod)}");
            }

            [Test]
            public void ReturnsNestedMemberNameForRefefrenceMethod()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.Nested.ReferenceMethod(), true);

                // Then
                name.ShouldBe($"{nameof(TestClass.Nested)}.{nameof(TestClass.ReferenceMethod)}");
            }

            [Test]
            public void ReturnsTwoLevelNestedMemberNameForRefefrenceMethod()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.Nested.Nested.ReferenceMethod(), true);

                // Then
                name.ShouldBe($"{nameof(TestClass.Nested)}.{nameof(TestClass.Nested)}.{nameof(TestClass.ReferenceMethod)}");
            }

            [Test]
            public void ReturnsNestedMemberNameForMethodWithParameters()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.Nested.ParamMethod(default(int), default(object)), true);

                // Then
                name.ShouldBe($"{nameof(TestClass.Nested)}.{nameof(TestClass.ParamMethod)}");
            }

            [Test]
            public void ReturnsTwoLevelNestedMemberNameForMethodWithParameters()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.Nested.Nested.ParamMethod(default(int), default(object)), true);

                // Then
                name.ShouldBe($"{nameof(TestClass.Nested)}.{nameof(TestClass.Nested)}.{nameof(TestClass.ParamMethod)}");
            }

            [Test]
            public void ReturnsNestedMemberNameForVoidMethod()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.Nested.VoidMethod(), true);

                // Then
                name.ShouldBe($"{nameof(TestClass.Nested)}.{nameof(TestClass.VoidMethod)}");
            }

            [Test]
            public void ReturnsTwoLevelNestedMemberNameForVoidMethod()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.Nested.Nested.VoidMethod(), true);

                // Then
                name.ShouldBe($"{nameof(TestClass.Nested)}.{nameof(TestClass.Nested)}.{nameof(TestClass.VoidMethod)}");
            }

            [Test]
            public void ShouldThrowForNullFunc()
            {
                // Given, When, Then
                Should.Throw<ArgumentNullException>(() => ExpressionHelper.GetMemberName<TestClass>((Expression<Func<TestClass, object>>)null));
            }

            [Test]
            public void ShouldThrowForNullAction()
            {
                // Given, When, Then
                Should.Throw<ArgumentNullException>(() => ExpressionHelper.GetMemberName<TestClass>((Expression<Action<TestClass>>)null));
            }
        }
    }
}
