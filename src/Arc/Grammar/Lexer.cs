using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Arc.Values;

namespace Arc.Grammar
{
    public sealed class Lexer : IEnumerable<IToken>
    {
        // TODO: Merge non-WS regexes into a single regex.
        private static readonly Regex Whitespace = new Regex(@"\G +", RegexOptions.Compiled);
        private static readonly Regex Number = new Regex(@"\G[+-]?[0-9]+(?:\.[0-9]+)?(?:[eE][+-]?[0-9]+)?", RegexOptions.Compiled);
        private static readonly Regex Boolean = new Regex(@"\Gtrue|false", RegexOptions.Compiled);
        private static readonly Regex Null = new Regex(@"\Gnull", RegexOptions.Compiled);
        private static readonly Regex MultiplicativeOperator = new Regex(@"\G*|/|%", RegexOptions.Compiled);
        private static readonly Regex AdditiveOperator = new Regex(@"\G+|-", RegexOptions.Compiled);

        private string _input;
        private int _index;

        public Lexer(string input, int index = 0)
        {
            _input = input;
            _index = index;
        }

        public IEnumerator<IToken> GetEnumerator()
        {
            while (_index < _input.Length)
            {
                Match match;
                match = Whitespace.Match(_input, _index);
                if (match.Success)
                    _index = match.Index + match.Length;
                match = Match(Number);
                if (match.Success)
                {
                    yield return new LiteralToken(NumberValue.Create(decimal.Parse(match.Value)));
                    continue;
                }
                match = Match(Boolean);
                if (match.Success)
                {
                    yield return new LiteralToken(BoolValue.Create(match.Value == "true"));
                    continue;
                }
                match = Match(Null);
                if (match.Success)
                {
                    yield return new LiteralToken(NullValue.Value);
                    continue;
                }
                match = Match(MultiplicativeOperator);
                if (match.Success)
                {
                    yield return new MultiplicativeOperatorToken(match.Value);
                    continue;
                }
                match = Match(AdditiveOperator);
                if (match.Success)
                {
                    yield return new AdditiveOperatorToken(match.Value);
                    continue;
                }
                throw new InvalidDataException("Could not parse at index " + _index);
            }
        }

        private Match Match(Regex regex)
        {
            var result = regex.Match(_input, _index);
            if (result.Success)
                _index = result.Index + result.Length;
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
