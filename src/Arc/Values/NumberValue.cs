using System;
using System.Globalization;

namespace Arc.Values
{
    public sealed class NumberValue : IValue
    {
        private static readonly NumberValue ZeroInstance = new NumberValue(decimal.Zero);

        private NumberValue(decimal value)
        {
            Value = value;
        }

        public static NumberValue Create(decimal value)
        {
            return value == 0 ? ZeroInstance : new NumberValue(value);
        }

        public static NumberValue Zero { get { return ZeroInstance; } }

        public decimal Value { get; private set; }

        public ulong BitwiseValue
        {
            get
            {
                try
                {
                    return Convert.ToUInt64(Value);
                }
                catch (OverflowException)
                {
                    return 0;
                }
            }
        }

        public BoolValue ImplicitConversionToBoolValue()
        {
            return Value == 0 ? BoolValue.False : BoolValue.True;
        }

        public NumberValue ImplicitConversionToNumberValue()
        {
            return this;
        }

        public StringValue ImplicitConversionToStringValue()
        {
            return StringValue.Create(Value.ToString("G16", CultureInfo.InvariantCulture));
        }
    }
}
