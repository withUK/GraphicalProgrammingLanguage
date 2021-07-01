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

            var type = Enum.Parse(typeof(CommandTypes), commandName);
            command = cf.getCommand(main, type.ToString());
                    
            switch (type)
            {
                case CommandTypes.clear:
                    (command as Clear).set(variableDict);
                    break;
                case CommandTypes.drawshape:
                    (command as DrawShape).set(variableDict);
                    break;
                case CommandTypes.drawto:
                    (command as DrawTo).set(variableDict);
                    break;
                case CommandTypes.moveto:
                    (command as MoveTo).set(variableDict);
                    break;
                case CommandTypes.reset:
                    (command as Reset).set(variableDict);
                    break;
                case CommandTypes.setpen:
                    (command as SetPen).set(variableDict);
                    break;
                default:
                    break;
            }

            command.execute();
            main.txtCommandLine.Clear();
        }
    }
}
