using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Factories.Tests
{
    /// <summary>
    /// Set of tests intended to test the functionality provided by the ShapesFactory class.
    /// </summary>
    [TestClass()]
    public class ShapeFactoryTests
    {
        private ShapeFactory f = new ShapeFactory();
        private MainGUI main = new MainGUI();

        /// <summary>
        /// Returns expected type of object as the shapeName suggests.
        /// </summary>
        /// <param name="shapeName">The name value of the intended command</param>
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

        /// <summary>
        /// Passes on return of ArgumentException which is expected if unknown string is passed to GetShape method.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetCommandTest_ReturnsException_WhenInVlaidShapeNamePassed()
        {
            var result = f.GetShape(main, "InvalidShape");
        }
    }
}