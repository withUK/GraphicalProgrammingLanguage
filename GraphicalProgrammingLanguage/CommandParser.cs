using GraphicalProgrammingLanguage.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage
{
    class CommandParser
    {
        // Properties
        private string commandType { get; set; }
        private string[] components { get; set; }
        private Command command { get; set; }
        private Dictionary<string,object> variables { get; set; }

        // Constructor
        public CommandParser(string input)
        {
            components = input.Split("(");
        }

        // Methods
        private void getCommandType(string input)
        {
            commandType = components[0];
        }

        private void getVariables(string input)
        {
            int startIndex = input.IndexOf("(");
            int endIndex = input.LastIndexOf(")");

            string variableString = input.Substring(startIndex + 1, endIndex);
            string[] variables = variableString.Split(",");
        }
    }
}
