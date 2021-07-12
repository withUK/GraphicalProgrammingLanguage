using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Tests
{
    /// <summary>
    /// Set of tests intended to test the functionality provided by the UsageCounter helper.
    /// </summary>
    [TestClass()]
    public class UsageCounterTests
    {
        /// <summary>
        /// Checks the number of command types present in the enum and checks the correct number of records are present 
        /// in the database table.
        /// </summary>
        [TestMethod]
        public void GetUsageCountOutput_ReturnsListOfFormattedStrings()
        {
            var result = UsageCounter.GetUsageCountOutput();
            var commandsCount = Enum.GetNames(typeof(Enums.CommandTypes)).Length;
            Assert.AreEqual(result.Count, commandsCount);
        }
    }
}