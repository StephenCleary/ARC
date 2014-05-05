using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arc.Grammar
{
    public sealed class AdditiveOperatorToken : StringTokenBase
    {
        public AdditiveOperatorToken(string text)
            : base(text)
        {
        }
    }
}
