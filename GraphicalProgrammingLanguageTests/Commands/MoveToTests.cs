﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Commands.Tests
{
    [TestClass()]
    public class MoveToTests
    {
        private MainGUI main = new MainGUI();

        [TestMethod()]
        public void Set_ReturnsTrueWhenSetsParameters()
        {
            MoveTo d = new MoveTo(main);
            Dictionary<string, string> v = new Dictionary<string, string>();

            int x = 4;
            int y = 5;

            v.Add("x", x.ToString());
            v.Add("y", y.ToString());
            d.set(v);

            Assert.IsTrue(d.hasRequiredParameters());
        }

        [TestMethod()]
        public void Set_ReturnsFalseWhenParametersNotFullySet()
        {
            MoveTo d = new MoveTo(main);
            Dictionary<string, string> v = new Dictionary<string, string>();

            int y = 5;

            v.Add("y", y.ToString());
            d.set(v);

            Assert.IsFalse(d.hasRequiredParameters());
        }
    }
}