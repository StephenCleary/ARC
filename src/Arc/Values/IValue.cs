namespace Arc.Values
{
    public interface IValue
    {
        BoolValue ImplicitConversionToBoolValue();

        NumberValue ImplicitConversionToNumberValue();

        StringValue ImplicitConversionToStringValue();

        // TODO: ToStringRepresentation()?
    }
}
