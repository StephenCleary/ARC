using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arc.Values;

namespace Arc.Grammar.Syntax
{
    public interface IOperatorNode : INode
    {
        string Operator { get; }
    }
}
