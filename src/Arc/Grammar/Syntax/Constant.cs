using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arc.Values;

namespace Arc.Grammar.Syntax
{
    public sealed class Constant : INode
    {
        private readonly IValue _value;

        public Constant(IValue value)
        {
            _value = value;
        }

        public IValue Evaluate()
        {
            return _value;
        }
    }
}
