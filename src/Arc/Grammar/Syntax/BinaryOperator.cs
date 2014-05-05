using System;
using Arc.Values;

namespace Arc.Grammar.Syntax
{
    public sealed class BinaryOperator : IOperatorNode, IBinaryNode
    {
        private readonly INode _left;
        private readonly INode _right;

        public BinaryOperator(string @operator, INode left, INode right)
        {
            Operator = @operator;
            _left = left;
            _right = right;
        }

        public string Operator { get; private set; }

        public IValue Evaluate()
        {
            if (Operator == "+")
                return NumberValue.Create(Left.Evaluate().ImplicitConversionToNumberValue().Value + Right.Evaluate().ImplicitConversionToNumberValue().Value);
            if (Operator == "-")
                return NumberValue.Create(Left.Evaluate().ImplicitConversionToNumberValue().Value - Right.Evaluate().ImplicitConversionToNumberValue().Value);
            if (Operator == "*")
                return NumberValue.Create(Left.Evaluate().ImplicitConversionToNumberValue().Value * Right.Evaluate().ImplicitConversionToNumberValue().Value);
            if (Operator == "/")
                return NumberValue.Create(Left.Evaluate().ImplicitConversionToNumberValue().Value / Right.Evaluate().ImplicitConversionToNumberValue().Value);
            if (Operator == "%")
                return NumberValue.Create(Left.Evaluate().ImplicitConversionToNumberValue().Value % Right.Evaluate().ImplicitConversionToNumberValue().Value);
            if (Operator == "@&")
                return NumberValue.Create(Left.Evaluate().ImplicitConversionToNumberValue().BitwiseValue & Right.Evaluate().ImplicitConversionToNumberValue().BitwiseValue);
            if (Operator == "@|")
                return NumberValue.Create(Left.Evaluate().ImplicitConversionToNumberValue().BitwiseValue | Right.Evaluate().ImplicitConversionToNumberValue().BitwiseValue);
            if (Operator == "@^")
                return NumberValue.Create(Left.Evaluate().ImplicitConversionToNumberValue().BitwiseValue ^ Right.Evaluate().ImplicitConversionToNumberValue().BitwiseValue);
            if (Operator == "&")
                return StringValue.Create(Left.Evaluate().ImplicitConversionToStringValue().Value + Right.Evaluate().ImplicitConversionToStringValue().Value);
            if (Operator == "&&")
                return BoolValue.Create(Left.Evaluate().ImplicitConversionToBoolValue().Value && Right.Evaluate().ImplicitConversionToBoolValue().Value);
            if (Operator == "||")
                return BoolValue.Create(Left.Evaluate().ImplicitConversionToBoolValue().Value || Right.Evaluate().ImplicitConversionToBoolValue().Value);
            throw new Exception("Internal error: no implementation for operator '" + Operator + "'"); // TODO: different exception type?
        }

        public INode Left
        {
            get { return _left; }
        }

        public INode Right
        {
            get { return _right; }
        }
    }
}
