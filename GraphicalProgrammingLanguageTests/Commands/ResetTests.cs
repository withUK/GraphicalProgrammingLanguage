using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Commands.Tests
{
    [TestClass()]
    public class ResetTests
    {
        private MainGUI main = new MainGUI();

        [TestMethod()]
        public void HasRequiredParametersTest_ReturnsTrue()
        {
            Reset c = new Reset(main);
            var result = c.hasRequiredParameters();
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsValid_ReturnsTrue()
        {
            Reset c = new Reset(main);
            var result = c.IsValid(new Dictionary<string, string>());
            Assert.IsTrue(result);
        }
    }
}