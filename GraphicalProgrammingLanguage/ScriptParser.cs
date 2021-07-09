using GraphicalProgrammingLanguage.Commands;
using GraphicalProgrammingLanguage.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GraphicalProgrammingLanguage
{
    public class ScriptParser
    {
        // Constants
        private const string REG_VARIABLE = "^var\\s[a-zA-Z]+=[a-zA-Z0-9]+$";
        private const string REG_METHOD = "^method\\s[a-zA-Z]+\\([a-zA-Z0-9,;]+\\)$";
        private const string REG_COMMAND = "^[a-zA-Z]+$";
        
        Regex regexVariable = new Regex(REG_VARIABLE, RegexOptions.IgnoreCase);
        Regex regexMethod = new Regex(REG_METHOD, RegexOptions.IgnoreCase);
        Regex regexCommand = new Regex(REG_COMMAND, RegexOptions.IgnoreCase);
        
        // Properties
        private MainGUI main { get; set; }
        private List<string> scriptLines { get; set; }
        private string[] scriptArray { get; set; }
        private CommandFactory cf = new CommandFactory();
        private Command command { get; set; }
        private Dictionary<string, string> variables;
        
        //private string[] script { get; set; }

        // Constructor
        public ScriptParser(MainGUI main)
        {
            this.main = main;
        }

        // Methods
        public void ParseScript()
        {
            PopulateScriptList();
        }

        private void PopulateScriptList()
        {
            while (main.fileContent.EndOfStream == false)
            {
                var line = main.fileContent.ReadLine();
                if (line == null) 
                    continue;

                scriptLines.Add(line);
            }
        }

        private void PopulateCommandsList()
        {
            scriptArray = scriptLines.GetRange(0, scriptLines.Count).ToArray();

            for (int i = 0; i < scriptArray.Length; i++)
            {
                var thisLine = scriptArray[i];

                if (regexCommand.IsMatch(thisLine))
                {
                    if (thisLine == "if" || thisLine == "for" || thisLine == "while")
                    {

                    }
                    else
                    {
                        Command currentCommand = cf.getCommand(main, thisLine);
                    }
                }
                if (regexVariable.IsMatch(thisLine))
                {

                }
                if (regexMethod.IsMatch(thisLine))
                {

                }
            }
        }
    }
}
