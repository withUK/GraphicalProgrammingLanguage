using GraphicalProgrammingLanguage.Commands;
using GraphicalProgrammingLanguage.Factories;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GraphicalProgrammingLanguage
{
    /// <summary>
    /// The command parser is used to take the input from the user and ascertains whether it matches syntax patterns 
    /// to draw out the command name and variables. When a command has the required parameters the parser executes and
    /// logs the action as successful.
    /// The MainGUI is passed within the constructor to ensure the GUI elements are available for access dependant on
    /// the command.
    /// </summary>
    public class CommandParser
    {
        // Constants
        private const string REG_PARENTHESES = "^[a-zA-Z]+\\([^)]*\\)$";
        private const string REG_COMMAND_ONLY = "^[a-zA-Z]+$";
        private const string REG_VARIABLE = "^[a-zA-Z]+=[a-zA-Z0-9]+$";
        private const string REG_VARIABLE_POINT = "^[a-zA-Z0-9]+=[0-9]+,[0-9]+$";

        Regex regexParentheses = new Regex(REG_PARENTHESES, RegexOptions.IgnoreCase);
        Regex regexCommandOnly = new Regex(REG_COMMAND_ONLY, RegexOptions.IgnoreCase);
        Regex regexVariables = new Regex(REG_VARIABLE, RegexOptions.IgnoreCase);
        Regex regexVariablesPoint = new Regex(REG_VARIABLE_POINT, RegexOptions.IgnoreCase);

        // Properties
        private MainGUI main { get; set; }
        private CommandFactory cf = new CommandFactory();
        private Command command { get; set; }
        private Dictionary<string, string> variables;

        // Constructor
        public CommandParser(MainGUI main)
        {
            this.main = main;
        }

        // Methods
        public void ParseCommand(string input)
        {
            input = PrepareInput(input);
            SetCommand(input);
            SetVariablesFromInput(input);

            if (command.hasRequiredParameters())
            {
                command.Execute();
                UsageCounter.AddToCommandCount(command.name);
                ClearCurrentCommand();
                UpdateCommandUsage();
            }
            else
            {
                SetCurrentCommand();
            }

            main.txtCommandLine.Clear();
        }

        /// <summary>
        /// The 'prepareInput' method takes a string input and converts to lowercase and then removes the whitespace to 
        /// ensure consistant evaluation and extraction of values.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string PrepareInput(string input)
        {
            input = input.ToLower().Trim();

            input = input.Replace(" ", "");

            return input;
        }

        /// <summary>
        /// 'setCommand' uses the REGEX patterns within the class to identify inputs containing parentheses or if it is
        /// a command on its own, further verification of the command is done within the command factory.
        /// </summary>
        /// <param name="input"></param>
        private void SetCommand(string input)
        {
            int index = 0;
            string commandType;

            if (regexParentheses.IsMatch(input))
            {
                index = input.IndexOf("(");
                commandType = input.Substring(0, index);

                command = cf.GetCommand(main, commandType);
            }
            else if (main.currentCommand != null)
            {
                command = main.currentCommand;
            }
            else if (regexCommandOnly.IsMatch(input))
            {
                command = cf.GetCommand(main, input);
            }
        }

        /// <summary>
        /// This method is used to cast the command object to the relavent command type and initiate the set method 
        /// appropriately passing the variables dictionary.
        /// </summary>
        private void SetCommandVariables()
        {
            switch (command.name)
            {
                case "drawshape":
                    (command as DrawShape).set(variables);
                    break;
                case "drawto":
                    (command as DrawTo).set(variables);
                    break;
                case "moveto":
                    (command as MoveTo).set(variables);
                    break;
                case "setfill":
                    (command as SetFill).set(variables);
                    break;
                case "setpen":
                    (command as SetPen).set(variables);
                    break;
                case "clear":
                case "reset":
                    break;
            }
        }

        /// <summary>
        /// Using the REGEX patterns the 'setVariablesFromInput method identifies whether the entered input string 
        /// hold variables, whether they are inside parentheses or stand alone variables.
        /// </summary>
        /// <param name="input"></param>
        private void SetVariablesFromInput(string input)
        {
            int startIndex = 0;
            int endIndex = 0;

            if (regexParentheses.IsMatch(input))
            {
                variables = new Dictionary<string, string>();

                startIndex = input.IndexOf("(");
                endIndex = input.IndexOf(")");

                string variablesString = input.Substring(startIndex + 1, endIndex - startIndex - 1);
                string[] split = variablesString.Split(",");
                foreach (var item in split)
                {
                    if (item.Contains("="))
                    {
                        string[] sp = item.Split("=");
                        variables.Add(sp[0], sp[1]);
                    }
                }
            }
            else if (main.currentCommand != null)
            {
                variables = main.currentVariables;
            }

            if (regexVariables.IsMatch(input) || regexVariablesPoint.IsMatch(input))
            {
                if (variables == null)
                    variables = new Dictionary<string, string>();

                string[] split = input.Split("=");
                variables.Add(split[0], split[1]);
            }

            SetCommandVariables();
        }

        /// <summary>
        /// This method assigns the built command to the MainGUI object. The purpose of this action is to store a partially
        /// created command object and variables until they are completed and can be executed.
        /// </summary>
        private void SetCurrentCommand()
        {
            main.currentCommand = command;
            main.currentVariables = variables;
        }

        /// <summary>
        /// As the command object within the MainGUI is used as storage for incomplete commands, this method is to clear the 
        /// object and variables.
        /// This is used on execution of the completed command or if the command is changed before completed.
        /// </summary>
        private void ClearCurrentCommand()
        {
            main.currentCommand = null;
            main.currentVariables = null;
        }

        /// <summary>
        /// A feature of the application is to 
        /// On completion of a command the txtCommandCount GUI object is updated with a formatted string value taken from the
        /// database and ordered by the number of calls to the command.
        /// </summary>
        private void UpdateCommandUsage()
        {
            List<string> usageOutput = new List<string>();
            usageOutput = UsageCounter.GetUsageCountOutput();

            main.txtCommandCount.Text = null;

            foreach (var item in usageOutput)
            {
                if (String.IsNullOrEmpty(main.txtCommandCount.Text))
                {
                    main.txtCommandCount.Text = item;
                }
                else
                {
                    main.txtCommandCount.Text = String.Concat(main.txtCommandCount.Text, "\n", item);
                }
            }
        }
    }
}
