using System.Collections.Generic;

namespace Arc
{
    public sealed class ObjectValue : IValue
    {
        public SortedDictionary<IValue, IValue> Members { get; private set; }
    }
}