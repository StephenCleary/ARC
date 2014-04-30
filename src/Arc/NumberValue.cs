using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arc
{
    public sealed class NumberValue : IValue
    {
        private static readonly NumberValue ZeroInstance = new NumberValue(0M);

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

        public BoolValue ToBoolValue()
        {
            return Value == 0 ? BoolValue.False : BoolValue.True;
        }

        public NumberValue ToNumberValue()
        {
            return this;
        }

        public StringValue ToStringValue()
        {
            // TODO: precision, culture
            return StringValue.Create(Value.ToString());
        }
    }
}
