using System;
using Arc.Values;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Tests
{
    [TestClass]
    public class ImplicitConversions
    {
        [TestMethod]
        public void Null_ToNumber_IsZero()
        {
            var value = NullValue.Value as IValue;
            var result = value.ImplicitConversionToNumberValue();
            Assert.AreEqual(0, result.Value);
        }

        [TestMethod]
        public void Null_ToString_IsEmpty()
        {
            var value = NullValue.Value as IValue;
            var result = value.ImplicitConversionToStringValue();
            Assert.AreEqual("", result.Value);
        }

        [TestMethod]
        public void Null_ToBool_IsFalse()
        {
            var value = NullValue.Value as IValue;
            var result = value.ImplicitConversionToBoolValue();
            Assert.AreEqual(false, result.Value);
        }

        [TestMethod]
        public void True_ToNumber_IsOne()
        {
            var value = BoolValue.Create(true) as IValue;
            var result = value.ImplicitConversionToNumberValue();
            Assert.AreEqual(1, result.Value);
        }

        [TestMethod]
        public void False_ToNumber_IsZero()
        {
            var value = BoolValue.Create(false) as IValue;
            var result = value.ImplicitConversionToNumberValue();
            Assert.AreEqual(0, result.Value);
        }

        [TestMethod]
        public void True_ToString_IsTrue()
        {
            var value = BoolValue.Create(true) as IValue;
            var result = value.ImplicitConversionToStringValue();
            Assert.AreEqual("true", result.Value);
        }

        [TestMethod]
        public void False_ToString_IsFalse()
        {
            var value = BoolValue.Create(false) as IValue;
            var result = value.ImplicitConversionToStringValue();
            Assert.AreEqual("false", result.Value);
        }

        [TestMethod]
        public void True_ToBool_IsTrue()
        {
            var value = BoolValue.Create(true) as IValue;
            var result = value.ImplicitConversionToBoolValue();
            Assert.AreEqual(true, result.Value);
        }

        [TestMethod]
        public void False_ToBool_IsFalse()
        {
            var value = BoolValue.Create(false) as IValue;
            var result = value.ImplicitConversionToBoolValue();
            Assert.AreEqual(false, result.Value);
        }

        [TestMethod]
        public void Function_ToBool_IsTrue()
        {
            var value = new FunctionValue("func") as IValue;
            var result = value.ImplicitConversionToBoolValue();
            Assert.AreEqual(true, result.Value);
        }

        [TestMethod]
        public void Function_ToNumber_IsZero()
        {
            var value = new FunctionValue("func") as IValue;
            var result = value.ImplicitConversionToNumberValue();
            Assert.AreEqual(0, result.Value);
        }

        [TestMethod]
        public void Function_ToString_IsEmpty()
        {
            var value = new FunctionValue("func") as IValue;
            var result = value.ImplicitConversionToStringValue();
            Assert.AreEqual(string.Empty, result.Value);
        }

        [TestMethod]
        public void NumberZero_ToBool_IsFalse()
        {
            var value = NumberValue.Create(0) as IValue;
            var result = value.ImplicitConversionToBoolValue();
            Assert.AreEqual(false, result.Value);
        }

        [TestMethod]
        public void NumberNonZero_ToBool_IsTrue()
        {
            var value = NumberValue.Create(-0.1M) as IValue;
            var result = value.ImplicitConversionToBoolValue();
            Assert.AreEqual(true, result.Value);
        }

        [TestMethod]
        public void Number_ToNumber_IsSameValue()
        {
            var value = NumberValue.Create(13) as IValue;
            var result = value.ImplicitConversionToNumberValue();
            Assert.AreEqual(13, result.Value);
        }

        [TestMethod]
        public void Number_ToString_IsStringRepresentationOfNumber()
        {
            var value = NumberValue.Create(-13.536M) as IValue;
            var result = value.ImplicitConversionToStringValue();
            Assert.AreEqual("-13.536", result.Value);
        }

        [TestMethod]
        public void StringEmpty_ToBool_IsFalse()
        {
            var value = StringValue.Create("") as IValue;
            var result = value.ImplicitConversionToBoolValue();
            Assert.AreEqual(false, result.Value);
        }

        [TestMethod]
        public void StringNonEmpty_ToBool_IsTrue()
        {
            var value = StringValue.Create("x") as IValue;
            var result = value.ImplicitConversionToBoolValue();
            Assert.AreEqual(true, result.Value);
        }

        [TestMethod]
        public void String_ToNumber_ParsesNumber()
        {
            var value = StringValue.Create("0.1357") as IValue;
            var result = value.ImplicitConversionToNumberValue();
            Assert.AreEqual(0.1357M, result.Value);
        }

        [TestMethod]
        public void StringNonNumber_ToNumber_IsZero()
        {
            var value = StringValue.Create("Bob") as IValue;
            var result = value.ImplicitConversionToNumberValue();
            Assert.AreEqual(0, result.Value);
        }

        [TestMethod]
        public void String_ToString_IsSameValue()
        {
            var value = StringValue.Create("V?") as IValue;
            var result = value.ImplicitConversionToStringValue();
            Assert.AreEqual("V?", result.Value);
        }

        [TestMethod]
        public void Object_ToString_IsEmpty()
        {
            var value = new ObjectValue() as IValue;
            var result = value.ImplicitConversionToStringValue();
            Assert.AreEqual("", result.Value);
        }

        [TestMethod]
        public void Object_ToNumber_IsZero()
        {
            var value = new ObjectValue() as IValue;
            var result = value.ImplicitConversionToNumberValue();
            Assert.AreEqual(0, result.Value);
        }

        [TestMethod]
        public void Object_ToBool_IsTrue()
        {
            var value = new ObjectValue() as IValue;
            var result = value.ImplicitConversionToBoolValue();
            Assert.AreEqual(true, result.Value);
        }
    }
}
