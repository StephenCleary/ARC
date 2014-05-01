namespace Arc.Values
{
    public sealed class NullValue : IValue
    {
        private static readonly NullValue Instance = new NullValue();

        private NullValue()
        {
        }

        public static NullValue Value { get { return Instance; } }

        public BoolValue ImplicitConversionToBoolValue()
        {
            return BoolValue.False;
        }

        public NumberValue ImplicitConversionToNumberValue()
        {
            return NumberValue.Zero;
        }

        public StringValue ImplicitConversionToStringValue()
        {
            return StringValue.Empty;
        }
    }
}