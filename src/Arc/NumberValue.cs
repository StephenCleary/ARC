using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arc
{
    public sealed class NumberValue : IValue
    {
        public decimal Value { get; private set; }
    }
}
