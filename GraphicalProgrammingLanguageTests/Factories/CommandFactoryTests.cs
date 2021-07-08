using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Factories.Tests
{
    [TestClass()]
    public class CommandFactoryTests
    {
        private CommandFactory f = new CommandFactory();
        private MainGUI main = new MainGUI();

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
            var result = f.getCommand(main, commandName);
            Assert.IsInstanceOfType(result, typeof(Commands.Command));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetCommandTest_ReturnsException_WhenInVlaidShapeNamePassed()
        {
            var result = f.getCommand(main, "InvalidCommand");
        }
    }
}