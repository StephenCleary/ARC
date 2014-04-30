using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arc
{
    public interface IValue
    {
        BoolValue ToBoolValue();

        NumberValue ToNumberValue();

        StringValue ToStringValue();

        // TODO: ToStringRepresentation()?
    }
}
