using System;
using System.Collections.Generic;
using System.Text;

namespace FluentFrontend.Vue
{
    /// <summary>
    /// Represents an attribute value that should be bound.
    /// </summary>
    public class BoundValue
    {
        public object Value { get; }

        public BoundValue(object value)
        {
            Value = value;
        }

        public static implicit operator BoundValue(string value) => new BoundValue(value);
    }

    /// <summary>
    /// A bound value that can be an expression or a specific type.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public class BoundValue<T> : BoundValue
    {
        public BoundValue(object value) : base(value)
        {
        }

        public BoundValue(T value) : base(value)
        {
        }

        public static implicit operator BoundValue<T>(T value) => new BoundValue<T>(value);

        public static implicit operator BoundValue<T>(string value) => new BoundValue<T>(value);
    }
}
