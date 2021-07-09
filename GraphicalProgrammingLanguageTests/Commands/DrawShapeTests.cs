using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Commands.Tests
{
    [TestClass()]
    public class DrawShapeTests
    {
        MainGUI main = new MainGUI();

        [TestMethod()]
        public void hasRequiredParameters_ReturnsFalseIfShapeIsNull()
        {
            DrawShape d = new DrawShape(main);
            var result = d.hasRequiredParameters();
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void hasRequiredParameters_ReturnsFalseIfShapeIsNotComplete()
        {
            DrawShape d = new DrawShape(main);
            Dictionary<string, string> v = new Dictionary<string, string>();
            v.Add("type", "circle");

            d.set(v);

            var result = d.hasRequiredParameters();
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void hasRequiredParameters_ReturnsTrueIfShapeIsComplete()
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

        [TestMethod()]
        public void isValid_ReturnsFalseIfShapeIsNull()
        {
            DrawShape d = new DrawShape(main);
            var result = d.isValid(new Dictionary<string, string>());
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void isValid_ReturnsFalseIfShapeIsNotComplete()
        {
            DrawShape d = new DrawShape(main);
            Dictionary<string, string> v = new Dictionary<string, string>();
            v.Add("type", "circle");

            d.set(v);

            var result = d.isValid(v);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void isValid_ReturnsTrueIfShapeIsComplete()
        {
            DrawShape d = new DrawShape(main);
            Dictionary<string, string> v = new Dictionary<string, string>();
            v.Add("type", "circle");
            v.Add("x", "5");
            v.Add("y", "5");
            v.Add("radius", "100");
            d.set(v);

            var result = d.isValid(v);
            Assert.IsTrue(result);
        }
    }
}