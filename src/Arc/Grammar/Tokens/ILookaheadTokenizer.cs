using System;
using System.Collections.Generic;

namespace Arc.Grammar.Tokens
{
    public interface ILookaheadTokenizer : IDisposable
    {
        // TODO: Handle lines and columns.
        char Current { get; }
        int CurrentIndex { get; }
        ILookaheadTokenizer MarkTokenStart();
        string Token { get; }
        string TokenDiscardingLast { get; }
        ILookaheadTokenizer Consume();
    }

    public static class LookaheadTokenizerExtensions
    {
        public static ILookaheadTokenizer Lookahead(this string source)
        {
            return new LookaheadTokenizer(source);
        }

        private sealed class LookaheadTokenizer : ILookaheadTokenizer
        {
            private readonly string _source;
            private readonly IEnumerator<char> _enumerator;
            private int _startIndex;
            private int _currentIndex;

            public LookaheadTokenizer(string source)
            {
                _source = source;
                _enumerator = source.GetEnumerator();
                _enumerator.MoveNext();
            }

            public char Current
            {
                get { return _enumerator.Current; }
            }

            public int CurrentIndex
            {
                get { return _currentIndex; }
            }

            public string Token
            {
                get { return _source.Substring(_startIndex, CurrentIndex - _startIndex); }
            }

            public string TokenDiscardingLast
            {
                get { return _source.Substring(_startIndex, CurrentIndex - _startIndex - 1); }
            }

            public ILookaheadTokenizer MarkTokenStart()
            {
                _startIndex = _currentIndex;
                return this;
            }

            public ILookaheadTokenizer Consume()
            {
                _enumerator.MoveNext();
                ++_currentIndex;
                return this;
            }

            public void Dispose()
            {
                _enumerator.Dispose();
            }
        }
    }
}
