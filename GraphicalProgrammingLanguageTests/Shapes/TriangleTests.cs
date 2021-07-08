using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage.Shapes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Shapes.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        private MainGUI main = new MainGUI();
        Triangle complete = new Triangle(1, 1, Color.Red, Color.Red, 1, 5, 1, 3, 5);
        Triangle partial = new Triangle();

        [TestMethod()]
        public void CalculateAreaTest_ReturnExpectedResultFromInput()
        {
            var result = complete.calculateArea();
            Assert.AreEqual(result, 8);
        }

        [TestMethod()]
        public void CalculatePerimeterTest_ReturnExpectedResultFromInput()
        {
            var result = complete.calculatePerimeter();
            Assert.AreEqual(result, 12.94427190999916);
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
            var expectedResult = "GraphicalProgrammingLanguage.Shapes.Triangle : x=1, y=1 : p1={X=1,Y=1}, p2={X=5,Y=1}, p3={X=3,Y=5}, perimeter=12.94427190999916, area=8";
            var result = complete.ToString();
            Assert.AreEqual(expectedResult, result);
        }
    }
}