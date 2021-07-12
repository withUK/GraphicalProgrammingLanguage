using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Commands.Tests
{
    /// <summary>
    /// Set of tests intended to test the core functionality of the Clear command object.
    /// </summary>
    [TestClass()]
    public class ClearTests
    {
        private MainGUI main = new MainGUI();

        /// <summary>
        /// Evaluating if instantiated, hasRequiredParameters methods returns true.
        /// </summary>
        [TestMethod()]
        public void HasRequiredParametersTest_ReturnsTrue()
        {
            Clear c = new Clear(main);
            var result = c.hasRequiredParameters();
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Evaluating if instantiated, IsValid methods returns true with empty dictionary object.
        /// </summary>
        [TestMethod()]
        public void IsValid_ReturnsTrue()
        {
            Clear c = new Clear(main);
            var result = c.IsValid(new Dictionary<string, string>());
            Assert.IsTrue(result);
        }
    }
}