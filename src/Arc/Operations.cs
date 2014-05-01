using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arc.Values;

namespace Arc
{
    public static class Operations
    {
        public static NumberValue UnaryPlus(IValue operand)
        {
            return NumberValue.Create(operand.ImplicitConversionToNumberValue().Value);
        }

        public static NumberValue Negate(IValue operand)
        {
            return NumberValue.Create(-operand.ImplicitConversionToNumberValue().Value);
        }

        public static NumberValue Increment(IValue operand)
        {
            return NumberValue.Create(operand.ImplicitConversionToNumberValue().Value + 1);
        }

        public static NumberValue Decrement(IValue operand)
        {
            return NumberValue.Create(operand.ImplicitConversionToNumberValue().Value - 1);
        }

        public static NumberValue Add(IValue left, IValue right)
        {
            return NumberValue.Create(left.ImplicitConversionToNumberValue().Value + right.ImplicitConversionToNumberValue().Value);
        }

        public static NumberValue Subtract(IValue left, IValue right)
        {
            return NumberValue.Create(left.ImplicitConversionToNumberValue().Value - right.ImplicitConversionToNumberValue().Value);
        }

        public static NumberValue Multiply(IValue left, IValue right)
        {
            return NumberValue.Create(left.ImplicitConversionToNumberValue().Value * right.ImplicitConversionToNumberValue().Value);
        }

        public static NumberValue Divide(IValue left, IValue right)
        {
            return NumberValue.Create(left.ImplicitConversionToNumberValue().Value / right.ImplicitConversionToNumberValue().Value);
        }

        public static NumberValue Modulus(IValue left, IValue right)
        {
            return NumberValue.Create(left.ImplicitConversionToNumberValue().Value % right.ImplicitConversionToNumberValue().Value);
        }

        public static NumberValue BitwiseNot(IValue operand)
        {
            return NumberValue.Create(~operand.ImplicitConversionToNumberValue().BitwiseValue);
        }

        public static NumberValue BitwiseAnd(IValue left, IValue right)
        {
            return NumberValue.Create(left.ImplicitConversionToNumberValue().BitwiseValue & right.ImplicitConversionToNumberValue().BitwiseValue);
        }

        public static NumberValue BitwiseOr(IValue left, IValue right)
        {
            return NumberValue.Create(left.ImplicitConversionToNumberValue().BitwiseValue | right.ImplicitConversionToNumberValue().BitwiseValue);
        }

        public static NumberValue BitwiseXor(IValue left, IValue right)
        {
            return NumberValue.Create(left.ImplicitConversionToNumberValue().BitwiseValue ^ right.ImplicitConversionToNumberValue().BitwiseValue);
        }

        public static StringValue Concatenate(IValue left, IValue right)
        {
            return StringValue.Create(left.ImplicitConversionToStringValue().Value + right.ImplicitConversionToStringValue().Value);
        }

        public static BoolValue LogicalNot(IValue operand)
        {
            return BoolValue.Create(!operand.ImplicitConversionToBoolValue().Value);
        }

        public static BoolValue LogicalAnd(IValue left, IValue right)
        {
            return BoolValue.Create(left.ImplicitConversionToBoolValue().Value && right.ImplicitConversionToBoolValue().Value);
        }

        public static BoolValue LogicalOr(IValue left, IValue right)
        {
            return BoolValue.Create(left.ImplicitConversionToBoolValue().Value || right.ImplicitConversionToBoolValue().Value);
        }
    }
}
