using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage.Shapes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Shapes.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        private MainGUI main = new MainGUI();
        Rectangle complete = new Rectangle(1, 1, 100, 50, Color.Red, Color.Red, 1);
        Rectangle partial = new Rectangle();

        [TestMethod()]
        public void CalculateAreaTest_ReturnExpectedResultFromInput()
        {
            var result = complete.calculateArea();
            Assert.AreEqual(result, 5000);
        }

        [TestMethod()]
        public void CalculatePerimeterTest_ReturnExpectedResultFromInput()
        {
            var result = complete.calculatePerimeter();
            Assert.AreEqual(result, 300);
        }

        [TestMethod()]
        public void HasRequiredVariables_ReturnsTrueIfAllVariablesSet()
        {
            var result = complete.hasRequiredVariables();
            Assert.IsTrue(result);
        }

        [DataTestMethod()]
        [DataRow("x", "1")]
        [DataRow("y", "1")]
        [DataRow("length", "100")]
        [DataRow("width", "50")]
        public void HasRequiredVariables_ReturnsFalseIfVariablesNot(string key, string value)
        {
            Dictionary<string, string> v = new Dictionary<string, string>();
            v.Add(key, value);
            partial.set(v);

            var result = partial.hasRequiredVariables();
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ToString_ReturnsExpectedStringValueWhenVariablesSet()
        {
            var expectedResult = "GraphicalProgrammingLanguage.Shapes.Rectangle : x=1, y=1 : length=100, width=50, perimeter=300, area=5000";
            var result = complete.ToString();
            Assert.AreEqual(expectedResult, result);
        }
    }
}