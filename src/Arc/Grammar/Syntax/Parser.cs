using Arc.Grammar.Tokens;

namespace Arc.Grammar.Syntax
{
    public sealed class Parser
    {
        private readonly Lexer _lexer;

        public Parser(string input)
        {
            _lexer = new Lexer(input);
        }

    }
}
