using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Tests
{
    [TestClass()]
    public class LoggerTests
    {
        [TestMethod]
        public void ReturnFormattedString_WhenLogLaunchCalled()
        {
            var expectedResult = $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} : Application started";
            var result = Logger.LogLaunch();
            Assert.AreEqual(result, expectedResult);
        }

        [DataTestMethod]
        [DataRow("HelloWorld")]
        [DataRow("")]
        [DataRow(null)]
        public void ReturnFormattedString_WhenLogCalled(string input)
        {
            var expectedResult = $"\n{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} : {input}";
            var result = Logger.Log(input);
            Assert.AreEqual(result, expectedResult);
        }
    }
}