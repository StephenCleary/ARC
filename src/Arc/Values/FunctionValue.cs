namespace Arc.Values
{
    public sealed class FunctionValue : IValue
    {
        public FunctionValue(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }

        public BoolValue ImplicitConversionToBoolValue()
        {
            return BoolValue.True;
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
