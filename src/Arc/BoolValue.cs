using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arc
{
    public sealed class BoolValue : IValue
    {
        private static readonly BoolValue FalseInstance = new BoolValue(false);
        private static readonly BoolValue TrueInstance = new BoolValue(true);

        private BoolValue(bool value)
        {
            Value = value;
        }

        public static BoolValue Create(bool value)
        {
            return value ? TrueInstance : FalseInstance;
        }

        public static BoolValue False { get { return FalseInstance; } }
        public static BoolValue True { get { return TrueInstance; } }

        public bool Value { get; private set; }

        public BoolValue ToBoolValue()
        {
            return this;
        }

        public NumberValue ToNumberValue()
        {
            return NumberValue.Create(Value ? 1M : 0M);
        }

        public StringValue ToStringValue()
        {
            return StringValue.Create(Value ? "true" : "false");
        }
    }
}
