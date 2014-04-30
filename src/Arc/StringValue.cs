using System;
using System.Globalization;

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

        public BoolValue ImplicitConversionToBoolValue()
        {
            return this == EmptyInstance ? BoolValue.False : BoolValue.True;
        }

        public NumberValue ImplicitConversionToNumberValue()
        {
            decimal result;
            if (!decimal.TryParse(Value, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
                return NumberValue.Zero;
            return NumberValue.Create(result);
        }

        public StringValue ImplicitConversionToStringValue()
        {
            return this;
        }
    }
}