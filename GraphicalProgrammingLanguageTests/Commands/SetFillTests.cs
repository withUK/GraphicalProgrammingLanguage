using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Commands.Tests
{
    [TestClass()]
    public class SetFillTests
    {
        private MainGUI main = new MainGUI();

        [TestMethod()]
        public void HasRequiredParameters_ReturnsTrueWhenSetsParameters()
        {
            SetFill d = new SetFill(main);
            Dictionary<string, string> v = new Dictionary<string, string>();

            v.Add("color", "red");
            d.set(v);

            Assert.IsTrue(d.hasRequiredParameters());
        }

        [TestMethod()]
        public void IsValidParameters_ReturnsTrueWhenSetsParameters()
        {
            SetFill d = new SetFill(main);
            Dictionary<string, string> v = new Dictionary<string, string>();

            v.Add("color", "red");
            d.set(v);

            Assert.IsTrue(d.IsValid(v));
        }
    }
}