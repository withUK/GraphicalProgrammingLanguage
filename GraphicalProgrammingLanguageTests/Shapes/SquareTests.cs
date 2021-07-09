using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage.Shapes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Shapes.Tests
{
    [TestClass()]
    public class SquareTests
    {
        private MainGUI main = new MainGUI();
        Square complete = new Square(1, 1, 100, Color.Red, Color.Red, 1);
        Square partial = new Square();

        [TestMethod()]
        public void CalculateAreaTest_ReturnExpectedResultFromInput()
        {
            var result = complete.CalculateArea();
            Assert.AreEqual(result, 10000);
        }

        [TestMethod()]
        public void CalculatePerimeterTest_ReturnExpectedResultFromInput()
        {
            var result = complete.CalculatePerimeter();
            Assert.AreEqual(result, 400);
        }

        [TestMethod()]
        public void HasRequiredVariables_ReturnsTrueIfAllVariablesSet()
        {
            var result = complete.HasRequiredVariables();
            Assert.IsTrue(result);
        }

        [DataTestMethod()]
        [DataRow("x", "1")]
        [DataRow("y", "1")]
        [DataRow("length", "100")]
        public void HasRequiredVariables_ReturnsFalseIfVariablesNot(string key, string value)
        {
            Dictionary<string, string> v = new Dictionary<string, string>();
            v.Add(key, value);
            partial.Set(v);

            var result = partial.HasRequiredVariables();
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ToString_ReturnsExpectedStringValueWhenVariablesSet()
        {
            var expectedResult = "GraphicalProgrammingLanguage.Shapes.Square : x=1, y=1 : length=100, perimeter=400, area=10000";
            var result = complete.ToString();
            Assert.AreEqual(expectedResult, result);
        }
    }
}