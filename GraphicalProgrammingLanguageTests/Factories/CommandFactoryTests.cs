using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Factories.Tests
{
    /// <summary>
    /// Set of tests intended to test the functionality provided by the CommandFactory class.
    /// </summary>
    [TestClass()]
    public class CommandFactoryTests
    {
        private CommandFactory f = new CommandFactory();
        private MainGUI main = new MainGUI();

        /// <summary>
        /// Returns expected type of object as the commandName suggests.
        /// </summary>
        /// <param name="commandName">The name value of the intended command</param>
        [DataTestMethod]
        [DataRow("clear")]
        [DataRow("drawshape")]
        [DataRow("drawto")]
        [DataRow("moveto")]
        [DataRow("reset")]
        [DataRow("setfill")]
        [DataRow("setpen")]
        public void GetCommandTest_ReturnsCommandType_WhenValidCommandNamePassed(string commandName)
        {
            var result = f.GetCommand(main, commandName);
            Assert.IsInstanceOfType(result, typeof(Commands.Command));
        }

        /// <summary>
        /// Passes on return of ArgumentException which is expected if unknown string is passed to GetCommand method.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetCommandTest_ReturnsException_WhenInVlaidShapeNamePassed()
        {
            var result = f.GetCommand(main, "InvalidCommand");
        }
    }
}