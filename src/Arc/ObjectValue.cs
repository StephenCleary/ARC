using System.Collections.Generic;

namespace Arc
{
    public sealed class ObjectValue : IValue
    {
        // TODO: comparer
        public SortedDictionary<IValue, IValue> Members { get; private set; }

        public BoolValue ToBoolValue()
        {
            // TODO: permit overload.
            return BoolValue.True;
        }

        public NumberValue ToNumberValue()
        {
            // TODO: permit overload.
            return NumberValue.Zero;
        }

        public StringValue ToStringValue()
        {
            // TODO: permit overload.
            return StringValue.Empty;
        }
    }
}