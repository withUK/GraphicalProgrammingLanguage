using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Commands.Tests
{
    /// <summary>
    /// Set of tests intended to test the core functionality of the SetFill command object.
    /// </summary>
    [TestClass()]
    public class SetFillTests
    {
        private MainGUI main = new MainGUI();

        /// <summary>
        /// Returns a true value when the required variables have been passed.
        /// </summary>
        [TestMethod()]
        public void HasRequiredParameters_ReturnsTrueWhenSetsParameters()
        {
            SetFill d = new SetFill(main);
            Dictionary<string, string> v = new Dictionary<string, string>();

            v.Add("color", "red");
            d.set(v);

            Assert.IsTrue(d.hasRequiredParameters());
        }

        /// <summary>
        /// Returns a true value when the required variables have been passed.
        /// </summary>
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