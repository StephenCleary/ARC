namespace Arc
{
    public sealed class NullValue : IValue
    {
        private static readonly NullValue Instance = new NullValue();

        private NullValue()
        {
        }

        public static NullValue Value { get { return Instance; } }

        public BoolValue ToBoolValue()
        {
            return BoolValue.False;
        }

        public NumberValue ToNumberValue()
        {
            return NumberValue.Zero;
        }

        public StringValue ToStringValue()
        {
            return StringValue.Empty;
        }
    }
}