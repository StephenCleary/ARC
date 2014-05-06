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
            using (var input = _input.Lookahead())
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
                        yield return new SymbolToken(input.Token);
                    }
                    else if (input.Current == '-')
                    {
                        input.MarkTokenStartAndConsume();
                        if (input.Current == '-' || input.Current == '=')
                            input.Consume();
                        yield return new SymbolToken(input.Token);
                    }
                    else if (input.Current == '!' || input.Current == '*' || input.Current == '/' || input.Current == '%' || input.Current == '=' || input.Current == '>' || input.Current == '<')
                    {
                        input.MarkTokenStartAndConsume();
                        if (input.Current == '=')
                            input.Consume();
                        yield return new SymbolToken(input.Token);
                    }
                    else if (input.Current == '&')
                    {
                        input.MarkTokenStartAndConsume();
                        if (input.Current == '&')
                            input.Consume();
                        yield return new SymbolToken(input.Token);
                    }
                    else if (input.Current == '@')
                    {
                        input.MarkTokenStartAndConsume();
                        if (input.Current != '&' && input.Current != '|' && input.Current != '^')
                            throw new Exception("Invalid operator '@'"); // TODO: ParseException
                        input.Consume();
                        yield return new SymbolToken(input.Token);
                    }
                    else if (input.Current == '?')
                    {
                        input.MarkTokenStartAndConsume();
                        if (input.Current == '?')
                            input.Consume();
                        yield return new SymbolToken(input.Token);
                    }
                    else if (input.Current == '|')
                    {
                        input.MarkTokenStartAndConsume();
                        if (input.Current != '|')
                            throw new Exception("Invalid operator '|'"); // TODO: ParseException
                        input.Consume();
                        yield return new SymbolToken(input.Token);
                    }
                    else if (input.Current == '(' || input.Current == ')' || input.Current == '{' || input.Current == '}' || input.Current == '[' || input.Current == ']' || input.Current == '.' || input.Current == ';' || input.Current == '~' || input.Current == ':')
                    {
                        input.MarkTokenStartAndConsume();
                        yield return new SymbolToken(input.Token);
                    }
                    else if (IsAlpha(input.Current) || input.Current == '_')
                    {
                        input.MarkTokenStartAndConsume();
                        while (IsAlpha(input.Current) || IsDigit(input.Current) || input.Current == '_')
                            input.Consume();
                        var token = input.Token;
                        if (token == "true")
                            yield return new LiteralToken(BoolValue.True);
                        else if (token == "false")
                            yield return new LiteralToken(BoolValue.False);
                        else if (token == "null")
                            yield return new LiteralToken(NullValue.Value);
                        else
                            yield return new WordToken(token);
                        // TODO: special handling for keywords?
                    }
                }

                yield return new EndOfInputToken();
            }
        }

        private static bool IsDigit(char ch)
        {
            return ch >= '0' && ch <= '9';
        }

        private static bool IsAlpha(char ch)
        {
            return (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z');
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
