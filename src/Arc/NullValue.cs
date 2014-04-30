namespace Arc
{
    public sealed class NullValue : IValue
    {
        private static readonly NullValue Instance = new NullValue();

        private NullValue()
        {
        }

        public static NullValue Value { get { return Instance; } }
    }
}