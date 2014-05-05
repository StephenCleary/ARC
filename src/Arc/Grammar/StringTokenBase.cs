using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arc.Grammar
{
    public abstract class StringTokenBase : IToken
    {
        protected StringTokenBase(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }
    }
}
