using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FluentFrontend
{
    /// <summary>
    /// Provides some extension methods for working with extension objects.
    /// </summary>
    /// <remarks>
    /// Adapted from http://joelabrahamsson.com/getting-property-and-method-names-using-static-reflection-in-c/.
    /// </remarks>
    public static class ExpressionHelper
    {
        /// <summary>
        /// Gets the member name in a simple expression.
        /// </summary>
        /// <typeparam name="T">The type of instance.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>The name of the member.</returns>
        public static string GetMemberName<T>(Expression<Func<T, object>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return GetMemberName(expression.Body);
        }

        /// <summary>
        /// Gets the member name in a simple expression.
        /// </summary>
        /// <typeparam name="T">The type of instance.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>The name of the member.</returns>
        public static string GetMemberName<T>(Expression<Action<T>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return GetMemberName(expression.Body);
        }

        private static string GetMemberName(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            switch (expression)
            {
                case MemberExpression memberExpression:
                    return memberExpression.Member.Name;
                case MethodCallExpression methodCallExpression:
                    return methodCallExpression.Method.Name;
                case UnaryExpression unaryExpression:
                    return unaryExpression.Operand is MethodCallExpression methodExpression
                        ? methodExpression.Method.Name
                        : ((MemberExpression)unaryExpression.Operand).Member.Name;
            }

            throw new ArgumentException("Invalid expression");
        }
    }
}
