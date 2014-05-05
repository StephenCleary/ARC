using System;
using System.Collections;
using System.Collections.Generic;
using Arc.Values;

namespace Arc.Grammar.Tokens
{
    public sealed class Lexer : IEnumerable<IToken>
    {
        private const char End = '\u0004';

        private readonly string _input;

        public Lexer(string input)
        {
            _input = input + End;
        }

        public IEnumerator<IToken> GetEnumerator()
        {
            using (var input = LookaheadTokenizerExtensions.Lookahead(_input))
            {
                while (input.Current != End)
                {
                    // TODO: whitespace is sometimes significant
                    while (input.Current == ' ')
                        input.Consume();

                    if (IsDigit(input.Current))
                    {
                        input.MarkTokenStartAndConsume();

                        // digit+
                        while (IsDigit(input.Current))
                            input.Consume();

                        // ["." digit+]
                        if (input.Current == '.')
                        {
                            input.Consume();
                            while (IsDigit(input.Current))
                                input.Consume();
                        }

                        // ["e" [sign] digit+]
                        if (input.Current == 'e' || input.Current == 'E')
                        {
                            input.Consume();
                            if (input.Current == '+' || input.Current == '-')
                                input.Consume();
                            while (IsDigit(input.Current))
                                input.Consume();
                        }

                        yield return new LiteralToken(NumberValue.Create(decimal.Parse(input.Token)));
                    }
                    else if (input.Current == '+')
                    {
                        input.MarkTokenStartAndConsume();
                        if (input.Current == '+' || input.Current == '=')
                            input.Consume();
                        yield return new OperatorToken(input.Token);
                    }
                    else if (input.Current == '-')
                    {
                        input.MarkTokenStartAndConsume();
                        if (input.Current == '-' || input.Current == '=')
                            input.Consume();
                        yield return new OperatorToken(input.Token);
                    }
                    else if (input.Current == '!' || input.Current == '*' || input.Current == '/' || input.Current == '%' || input.Current == '=' || input.Current == '>' || input.Current == '<')
                    {
                        input.MarkTokenStartAndConsume();
                        if (input.Current == '=')
                            input.Consume();
                        yield return new OperatorToken(input.Token);
                    }
                    else if (input.Current == '&')
                    {
                        input.MarkTokenStartAndConsume();
                        if (input.Current == '&')
                            input.Consume();
                        yield return new OperatorToken(input.Token);
                    }
                    else if (input.Current == '@')
                    {
                        input.MarkTokenStartAndConsume();
                        if (input.Current != '&' && input.Current != '|' && input.Current != '^')
                            throw new Exception("Invalid operator '@'"); // TODO: ParseException
                        input.Consume();
                        yield return new OperatorToken(input.Token);
                    }
                }
            }
        }

        private static bool IsDigit(char ch)
        {
            return ch >= '0' && ch <= '9';
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
