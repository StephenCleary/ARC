using System;
using Arc.Grammar.Syntax;
using Arc.Grammar.Tokens;
using Arc.Values;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Tests
{
    [TestClass]
    public class Parsing
    {
        [TestMethod]
        public void True_ParsedAsConstant()
        {
            var result = new Parser(new Lexer("true")).Parse().Evaluate();
            Assert.IsInstanceOfType(result, typeof(BoolValue));
            Assert.IsTrue(((BoolValue)result).Value);
        }

        [TestMethod]
        public void False_ParsedAsConstant()
        {
            var result = new Parser(new Lexer("false")).Parse().Evaluate();
            Assert.IsInstanceOfType(result, typeof(BoolValue));
            Assert.IsFalse(((BoolValue)result).Value);
        }

        [TestMethod]
        public void Null_ParsedAsConstant()
        {
            var result = new Parser(new Lexer("null")).Parse().Evaluate();
            Assert.IsInstanceOfType(result, typeof(NullValue));
        }

        [TestMethod]
        public void Zero_ParsedAsConstant()
        {
            var result = new Parser(new Lexer("0")).Parse().Evaluate();
            Assert.IsInstanceOfType(result, typeof(NumberValue));
            Assert.AreEqual(0, ((NumberValue)result).Value);
        }
    }
}
