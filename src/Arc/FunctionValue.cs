using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arc
{
    public sealed class FunctionValue : IValue
    {
        public FunctionValue(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }

        public BoolValue ToBoolValue()
        {
            return BoolValue.True;
        }

        public NumberValue ToNumberValue()
        {
            return NumberValue.Zero;
        }

        public StringValue ToStringValue()
        {
            return StringValue.Empty;
        }
    }
}
