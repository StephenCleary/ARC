using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arc.Grammar
{
    public sealed class MultiplicativeOperatorToken : StringTokenBase
    {
        public MultiplicativeOperatorToken(string text)
            : base(text)
        {
        }
    }
}
