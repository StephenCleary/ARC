using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arc.Values;

namespace Arc.Grammar.Syntax
{
    public sealed class UnaryOperator : IOperatorNode
    {
        public UnaryOperator(string @operator, INode operand)
        {
            Operand = operand;
            Operator = @operator;
        }

        public INode Operand { get; private set; }

        public IValue Evaluate()
        {
            if (Operator == "+")
                return Operand.Evaluate().ImplicitConversionToNumberValue();
            if (Operator == "-")
                return NumberValue.Create(-Operand.Evaluate().ImplicitConversionToNumberValue().Value);
            if (Operator == "~")
                return NumberValue.Create(~Operand.Evaluate().ImplicitConversionToNumberValue().BitwiseValue);
            if (Operator == "!")
                return BoolValue.Create(!Operand.Evaluate().ImplicitConversionToBoolValue().Value);
            if (Operator == "++")
                return NumberValue.Create(Operand.Evaluate().ImplicitConversionToNumberValue().Value + 1);
            if (Operator == "--")
                return NumberValue.Create(Operand.Evaluate().ImplicitConversionToNumberValue().Value - 1);
            throw new Exception("Internal error: no implementation for operator '" + Operator + "'"); // TODO: different exception type?
        }

        public string Operator { get; private set; }
    }
}
