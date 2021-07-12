using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Tests
{
    /// <summary>
    /// Set of tests intended to test the functionality provided by the Logger helper.
    /// </summary>
    [TestClass()]
    public class LoggerTests
    {
        /// <summary>
        /// Prepares a string that would be expected at the time of running the test. 
        /// This is evaluated againt the value returned from the tested method and passes if matched.
        /// </summary>
        [TestMethod]
        public void ReturnFormattedString_WhenLogLaunchCalled()
        {
            var expectedResult = $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} : Application started";
            var result = Logger.LogLaunch();
            Assert.AreEqual(result, expectedResult);
        }

        /// <summary>
        /// Prepares a string that would be expected at the time of running the test. 
        /// This is evaluated againt the value returned from the tested method and passes if matched.
        /// </summary>
        /// <param name="input">Value to be passed to the method and string builder</param>
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