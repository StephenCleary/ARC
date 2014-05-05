using Arc.Values;

namespace Arc.Grammar.Tokens
{
    public sealed class LiteralToken : IToken
    {
        public LiteralToken(IValue value)
        {
            Value = value;
        }

        public IValue Value { get; private set; }
    }
}
