using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Commands.Tests
{
    /// <summary>
    /// Set of tests intended to test the core functionality of the DrawShape command object.
    /// </summary>
    [TestClass()]
    public class DrawShapeTests
    {
        MainGUI main = new MainGUI();

        /// <summary>
        /// Returns a false value when the shape object is null.
        /// </summary>
        [TestMethod()]
        public void HasRequiredParameters_ReturnsFalseIfShapeIsNull()
        {
            DrawShape d = new DrawShape(main);
            var result = d.hasRequiredParameters();
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Returns a false value when the shape object is set but the variables have not.
        /// </summary>
        [TestMethod()]
        public void HasRequiredParameters_ReturnsFalseIfShapeIsNotComplete()
        {
            DrawShape d = new DrawShape(main);
            Dictionary<string, string> v = new Dictionary<string, string>();
            v.Add("type", "circle");

            d.set(v);

            var result = d.hasRequiredParameters();
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Returns a true value when the shape object is set and required variables have been passed.
        /// </summary>
        [TestMethod()]
        public void HasRequiredParameters_ReturnsTrueIfShapeIsComplete()
        {
            DrawShape d = new DrawShape(main);
            Dictionary<string, string> v = new Dictionary<string, string>();
            v.Add("type", "circle");
            v.Add("x", "5");
            v.Add("y", "5");
            v.Add("radius", "100");
            d.set(v);

            var result = d.hasRequiredParameters();
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Returns a false value when the shape object is null.
        /// </summary>
        [TestMethod()]
        public void IsValid_ReturnsFalseIfShapeIsNull()
        {
            DrawShape d = new DrawShape(main);
            var result = d.IsValid(new Dictionary<string, string>());
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Returns a false value when the shape object is set but the variables have not.
        /// </summary>
        [TestMethod()]
        public void IsValid_ReturnsFalseIfShapeIsNotComplete()
        {
            DrawShape d = new DrawShape(main);
            Dictionary<string, string> v = new Dictionary<string, string>();
            v.Add("type", "circle");

            d.set(v);

            var result = d.IsValid(v);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Returns a true value when the shape object is set and required variables have been passed.
        /// </summary>
        [TestMethod()]
        public void IsValid_ReturnsTrueIfShapeIsComplete()
        {
            DrawShape d = new DrawShape(main);
            Dictionary<string, string> v = new Dictionary<string, string>();
            v.Add("type", "circle");
            v.Add("x", "5");
            v.Add("y", "5");
            v.Add("radius", "100");
            d.set(v);

            var result = d.IsValid(v);
            Assert.IsTrue(result);
        }
    }
}