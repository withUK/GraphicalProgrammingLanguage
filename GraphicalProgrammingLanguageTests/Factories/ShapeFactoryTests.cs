using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Factories.Tests
{
    [TestClass()]
    public class ShapeFactoryTests
    {
        private ShapeFactory f = new ShapeFactory();
        private MainGUI main = new MainGUI();

        [DataTestMethod]
        [DataRow("circle")]
        [DataRow("rectangle")]
        [DataRow("square")]
        [DataRow("triangle")]
        public void GetCommandTest_ReturnsShapeType_WhenValidShapeNamePassed(string shapeName)
        {
            var result = f.GetShape(main, shapeName);
            Assert.IsInstanceOfType(result, typeof(Shapes.Shape));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetCommandTest_ReturnsException_WhenInVlaidShapeNamePassed()
        {
            var result = f.GetShape(main, "InvalidShape");
        }
    }
}