using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Tests
{
    [TestClass()]
    public class UsageCounterTests
    {
        [TestMethod]
        public void GetUsageCountOutput_ReturnsListOfFormattedStrings()
        {
            var result = UsageCounter.GetUsageCountOutput();
            var commandsCount = Enum.GetNames(typeof(Enums.CommandTypes)).Length;
            Assert.AreEqual(result.Count, commandsCount);
        }
    }
}