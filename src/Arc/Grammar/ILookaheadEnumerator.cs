using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arc.Grammar
{
    public interface ILookaheadEnumerator<out T> : IDisposable
    {
        bool Done { get; }
        T Current { get; }
        bool Consume();
    }

    public static class LookaheadEnumeratorExtensions
    {
        public static ILookaheadEnumerator<T> Lookahead<T>(this IEnumerable<T> source)
        {
            return new LookaheadEnumerator<T>(source);
        }

        public static T CurrentAndThenConsume<T>(this ILookaheadEnumerator<T> source)
        {
            var result = source.Current;
            source.Consume();
            return result;
        }

        private sealed class LookaheadEnumerator<T> : ILookaheadEnumerator<T>
        {
            private readonly IEnumerator<T> _source;

            public LookaheadEnumerator(IEnumerable<T> source)
            {
                _source = source.GetEnumerator();
                Done = _source.MoveNext();
            }

            public bool Done { get; private set; }

            public T Current
            {
                get { return _source.Current; }
            }

            public bool Consume()
            {
                Done = _source.MoveNext();
                return Done;
            }

            public void Dispose()
            {
                _source.Dispose();
            }
        }
    }
}
