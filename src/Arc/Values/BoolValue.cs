namespace Arc.Values
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

        public BoolValue ImplicitConversionToBoolValue()
        {
            return this;
        }

        public NumberValue ImplicitConversionToNumberValue()
        {
            return NumberValue.Create(Value ? 1M : 0M);
        }

        public StringValue ImplicitConversionToStringValue()
        {
            return StringValue.Create(Value ? "true" : "false");
        }
    }
}
