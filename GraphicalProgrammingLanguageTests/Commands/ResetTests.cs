using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Commands.Tests
{
    /// <summary>
    /// Set of tests intended to test the core functionality of the Reset command object.
    /// </summary>
    [TestClass()]
    public class ResetTests
    {
        private MainGUI main = new MainGUI();

        /// <summary>
        /// Evaluating if instantiated, hasRequiredParameters methods returns true.
        /// </summary>
        [TestMethod()]
        public void HasRequiredParametersTest_ReturnsTrue()
        {
            Reset c = new Reset(main);
            var result = c.hasRequiredParameters();
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Evaluating if instantiated, IsValid methods returns true with empty dictionary object.
        /// </summary>
        [TestMethod()]
        public void IsValid_ReturnsTrue()
        {
            Reset c = new Reset(main);
            var result = c.IsValid(new Dictionary<string, string>());
            Assert.IsTrue(result);
        }
    }
}