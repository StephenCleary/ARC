using System.Collections.Generic;

namespace Arc
{
    public sealed class ObjectValue : IValue
    {
        // TODO: comparer
        // TODO: don't expose dict
        public SortedDictionary<IValue, IValue> Members { get; private set; }

        public BoolValue ImplicitConversionToBoolValue()
        {
            // TODO: permit overload.
            return BoolValue.True;
        }

        public NumberValue ImplicitConversionToNumberValue()
        {
            // TODO: permit overload.
            return NumberValue.Zero;
        }

        public StringValue ImplicitConversionToStringValue()
        {
            // TODO: permit overload.
            return StringValue.Empty;
        }
    }
}