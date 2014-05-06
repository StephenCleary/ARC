using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arc.Grammar.Tokens
{
    public sealed class WordToken : StringTokenBase
    {
        public WordToken(string text)
            : base(text)
        {
        }
    }
}
