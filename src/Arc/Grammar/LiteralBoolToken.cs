using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arc.Values;

namespace Arc.Grammar
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
