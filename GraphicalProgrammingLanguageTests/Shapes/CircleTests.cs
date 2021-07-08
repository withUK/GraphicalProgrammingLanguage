using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Shapes.Tests
{
    [TestClass()]
    public class CircleTests
    {
        private MainGUI main = new MainGUI();
        Circle complete = new Circle(1, 1, 100, Color.Red, Color.Red, 1);
        Circle partial = new Circle();

        [TestMethod()]
        public void CalculateAreaTest_ReturnExpectedResultFromInput()
        {
            var result = complete.calculateArea();
            Assert.AreEqual(result, 320.4424506661589);
        }

        [TestMethod()]
        public void CalculatePerimeterTest_ReturnExpectedResultFromInput()
        {
            var result = complete.calculatePerimeter();
            Assert.AreEqual(result, 628.3185307179587);
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
        [DataRow("radius", "1")]
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
            var expectedResult = "GraphicalProgrammingLanguage.Shapes.Circle : x=1, y=1 : radius=100, perimeter=628.3185307179587, area=320.4424506661589";
            var result = complete.ToString();
            Assert.AreEqual(expectedResult, result);
        }
    }
}