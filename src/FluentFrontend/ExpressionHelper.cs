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
        /// <param name="nested">If <c>true</c> then the full nested property name and all parent properties will be returned.</param>
        /// <returns>The name of the member.</returns>
        public static string GetMemberName<T>(Expression<Func<T, object>> expression, bool nested = false) => GetMemberName(expression?.Body, nested);

        /// <summary>
        /// Gets the member name in a simple expression.
        /// </summary>
        /// <typeparam name="T">The type of instance.</typeparam>
        /// <typeparam name="TProperty">The type of property.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="nested">If <c>true</c> then the full nested property name and all parent properties will be returned.</param>
        /// <returns>The name of the member.</returns>
        public static string GetMemberName<T, TProperty>(Expression<Func<T, TProperty>> expression, bool nested = false) => GetMemberName(expression?.Body, nested);

        /// <summary>
        /// Gets the member name in a simple expression.
        /// </summary>
        /// <typeparam name="T">The type of instance.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="nested">If <c>true</c> then the full nested property name and all parent properties will be returned.</param>
        /// <returns>The name of the member.</returns>
        public static string GetMemberName<T>(Expression<Action<T>> expression, bool nested = false) => GetMemberName(expression?.Body, nested);

        private static string GetMemberName(Expression expression, bool nested)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            if (nested && 
                (expression.NodeType == ExpressionType.Convert
                || expression.NodeType == ExpressionType.ConvertChecked))
            {
                expression = (expression as UnaryExpression)?.Operand;
            }

            Stack<string> names = new Stack<string>();
            while (expression != null)
            {
                switch (expression)
                {
                    case MemberExpression memberExpression:
                        names.Push(memberExpression.Member.Name);
                        expression = memberExpression.Expression as MemberExpression;
                        break;
                    case MethodCallExpression methodCallExpression:
                        names.Push(methodCallExpression.Method.Name);
                        expression = methodCallExpression.Object;
                        break;
                    case UnaryExpression unaryExpression:
                        names.Push(unaryExpression.Operand is MethodCallExpression methodExpression
                            ? methodExpression.Method.Name
                            : ((MemberExpression) unaryExpression.Operand).Member.Name);
                        expression = null;
                        break;
                    default:
                        expression = (expression as MemberExpression)?.Expression as MemberExpression;
                        break;
                }
                if (!nested)
                {
                    break;
                }
            }

            if (names.Count == 0)
            {
                throw new ArgumentException("Invalid expression");
            }
            return string.Join(".", names);
        }
    }
}
