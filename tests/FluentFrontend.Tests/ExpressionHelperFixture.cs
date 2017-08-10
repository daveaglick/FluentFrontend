using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using NUnit.Framework;
using FluentFrontend;

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
                Assert.That(name, Is.EqualTo(nameof(TestClass.ValueProp)));
            }

            [Test]
            public void ReturnsMemberNameForReferenceType()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.ReferenceProp);

                // Then
                Assert.That(name, Is.EqualTo(nameof(TestClass.ReferenceProp)));
            }

            [Test]
            public void ReturnsMemberNameForValueMethod()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.ValueMethod());

                // Then
                Assert.That(name, Is.EqualTo(nameof(TestClass.ValueMethod)));
            }

            [Test]
            public void ReturnsMemberNameForRefefrenceMethod()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.ReferenceMethod());

                // Then
                Assert.That(name, Is.EqualTo(nameof(TestClass.ReferenceMethod)));
            }

            [Test]
            public void ReturnsMemberNameForMethodWithParameters()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.ParamMethod(default(int), default(object)));

                // Then
                Assert.That(name, Is.EqualTo(nameof(TestClass.ParamMethod)));
            }

            [Test]
            public void ReturnsMemberNameForVoidMethod()
            {
                // Given, When
                string name = ExpressionHelper.GetMemberName<TestClass>(x => x.VoidMethod());

                // Then
                Assert.That(name, Is.EqualTo(nameof(TestClass.VoidMethod)));
            }

            [Test]
            public void ShouldThrowForNullFunc()
            {
                // Given, When, Then
                Assert.Throws<ArgumentNullException>(() => ExpressionHelper.GetMemberName<TestClass>((Expression<Func<TestClass, object>>)null));
            }

            [Test]
            public void ShouldThrowForNullAction()
            {
                // Given, When, Then
                Assert.Throws<ArgumentNullException>(() => ExpressionHelper.GetMemberName<TestClass>((Expression<Action<TestClass>>)null));
            }
        }
    }
}
