using System;
using System.Collections.Generic;
using Arc.Grammar.Tokens;
using Arc.Values;

namespace Arc.Grammar.Syntax
{
    public sealed class Parser : IDisposable
    {
        private readonly IEnumerator<IToken> _input;

        public Parser(IEnumerable<IToken> input)
        {
            _input = input.GetEnumerator();
            _input.MoveNext();
        }

        public INode Parse()
        {
            while (!(_input.Current is EndOfInputToken))
            {
                var literalToken = _input.Current as LiteralToken;
                if (literalToken != null)
                    return new Constant(literalToken.Value);
                throw new Exception(); // TODO: SyntaxException
            }
            throw new Exception(); // TODO: SyntaxException
        }

        public void Dispose()
        {
            _input.Dispose();
        }
    }
}
