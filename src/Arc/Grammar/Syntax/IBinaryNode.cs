using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arc.Grammar.Syntax
{
    public interface IBinaryNode : INode
    {
        INode Left { get; }
        INode Right { get; }
    }
}
