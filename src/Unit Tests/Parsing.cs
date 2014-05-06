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
        public void BooleanTrue_ParsedAsConstant()
        {
            var result = new Parser(new Lexer("true")).Parse().Evaluate() as BoolValue;
            Assert.IsTrue(result.Value);
        }
    }
}
