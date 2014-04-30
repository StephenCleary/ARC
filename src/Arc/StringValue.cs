using System;

namespace Arc
{
    public sealed class StringValue : IValue
    {
        private static readonly StringValue EmptyInstance = new StringValue(string.Empty);

        private StringValue(string value)
        {
            Value = value;
        }

        public static StringValue Create(string value)
        {
            if (string.IsNullOrEmpty(value))
                return EmptyInstance;
            return new StringValue(value);
        }

        public static StringValue Empty { get { return EmptyInstance; } }

        public string Value { get; private set; }

        public BoolValue ToBoolValue()
        {
            return this == EmptyInstance ? BoolValue.False : BoolValue.True;
        }

        public NumberValue ToNumberValue()
        {
            // TODO: Allow hex, etc? Probably not; have stdlib support for that.
            decimal result;
            if (!decimal.TryParse(Value, out result))
                throw new InvalidCastException("Failed to convert string to number: " + Value);
            return NumberValue.Create(result);
        }

        public StringValue ToStringValue()
        {
            return this;
        }
    }
}