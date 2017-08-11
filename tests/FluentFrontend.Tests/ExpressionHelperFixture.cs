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
        public class GetMemberNameTests : ExpressionHelperFixture
        {
            public class TestClass
            {
                public int ValueProp { get; set; }
                public int ValueMethod() => 0;
                public object ReferenceProp { get; set; }
                public object ReferenceMethod() => null;
                public object ParamMethod(int x, object y) => null;
                public void VoidMethod() {}
            }

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
