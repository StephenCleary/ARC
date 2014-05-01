using System;
using System.Diagnostics;
using Arc;
using Arc.Values;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Tests
{
    [TestClass]
    public class Types
    {
        [TestMethod]
        public void Number_IsDecimal()
        {
            {
                double x = 0.1;
                double sum = 0.0;
                for (int i = 0; i != 10; ++i)
                    sum += x;
                Trace.WriteLine("Floating-point result: " + sum.ToString("R"));
            }
            {
                var x = NumberValue.Create(0.1M);
                var sum = NumberValue.Zero;
                for (int i = 0; i != 10; ++i)
                    sum = NumberValue.Create(sum.Value + x.Value);
                Trace.WriteLine("Number result: " + sum.Value);
                Assert.AreEqual(1, sum.Value);
            }
        }

        // todo: string precision.
    }
}
