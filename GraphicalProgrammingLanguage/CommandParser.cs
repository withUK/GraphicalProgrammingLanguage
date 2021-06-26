using GraphicalProgrammingLanguage.Commands;
using GraphicalProgrammingLanguage.Enums;
using GraphicalProgrammingLanguage.Factories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GraphicalProgrammingLanguage
{
    public class CommandParser
    {
        // Properties
        private string commandName { get; set; }
        string variableString { get; set; }
        private string[] variableStrings { get; set; }
        private Dictionary<string, string> variableDict;
        private CommandFactory cf = new CommandFactory();
        private Command command { get; set; }
        
        int startIndex = 0;
        int endIndex = 0;

        // Constructor
        public CommandParser()
        {
            
        }

        // Methods
        public void executeCommand(string input, MainGUI main)
        {
            variableDict = new Dictionary<string, string>();
            getCommandNameFromInput(input);
            getVariablesFromInput(input);

            var type = Enum.Parse(typeof(CommandTypes), commandName);
            command = cf.getCommand(main, type.ToString());
                    
            switch (type)
            {
                case CommandTypes.clear:
                    (command as Clear).set(main, variableDict);
                    break;
                case CommandTypes.drawShape:
                    (command as DrawShape).set(main, variableDict);
                    break;
                case CommandTypes.drawTo:
                    (command as DrawTo).set(main, variableDict);
                    break;
                case CommandTypes.moveTo:
                    (command as MoveTo).set(main, variableDict);
                    break;
                case CommandTypes.reset:
                    (command as Reset).set(main, variableDict);
                    break;
                default:
                    break;
            }

            command.log();
            command.execute();
            main.txtCommandLine.Clear();
        }

        private void getCommandNameFromInput(string input)
        {
            if (input.Contains("(") && input.Contains(")"))
            {
                startIndex = input.IndexOf("(");
                endIndex = input.LastIndexOf(")");
                commandName = input.Substring(0, startIndex);
            }
            else
            {
                commandName = input;
            }
        }

        private void getVariablesFromInput(string input)
        {
            if(input.Contains("(") && input.Contains(")"))
            {
                variableString = input.Substring(startIndex + 1, endIndex - startIndex - 1);
                variableStrings = variableString.Split(",");

                foreach (var item in variableStrings)
                {
                    string[] split = item.Split("=");
                    variableDict.Add(split[0], split[1]);
                }
            }
        }
    }
}
