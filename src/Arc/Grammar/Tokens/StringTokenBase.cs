namespace Arc.Grammar.Tokens
{
    public abstract class StringTokenBase : IToken
    {
        protected StringTokenBase(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }
    }
}
