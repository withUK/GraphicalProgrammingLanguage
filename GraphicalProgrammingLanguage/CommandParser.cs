using GraphicalProgrammingLanguage.Commands;
using GraphicalProgrammingLanguage.Data;
using GraphicalProgrammingLanguage.Enums;
using GraphicalProgrammingLanguage.Factories;
using GraphicalProgrammingLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GraphicalProgrammingLanguage
{
    public class CommandParser
    {
        // Constants
        private const string REG_PARENTHESES = "^[a-zA-Z]+\\([^)]*\\)$";
        private const string REG_COMMAND_ONLY = "^[a-zA-Z]+$";
        private const string REG_VARIABLE = "^[a-zA-Z]+=[a-zA-Z0-9]+$";

        Regex regexParentheses = new Regex(REG_PARENTHESES, RegexOptions.IgnoreCase);
        Regex regexCommandOnly = new Regex(REG_COMMAND_ONLY, RegexOptions.IgnoreCase);
        Regex regexVariables = new Regex(REG_VARIABLE, RegexOptions.IgnoreCase);

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
        public void parseCommand(string input)
        {
            input = prepareInput(input);
            setCommand(input);
            setVariablesFromInput(input);

            if (command.hasRequiredParameters())
            {
                command.execute();
                UsageCounter.AddToCommandCount(command.name);
                clearCurrentCommand();
                updateCommandUsage();
            }
            else
            {
                setCurrentCommand();
            }

            main.txtCommandLine.Clear();
        }

        private string prepareInput(string input)
        {
            input = input.ToLower().Trim();

            input = input.Replace(" ", "");

            return input;
        }

        private void setCommand(string input)
        {
            int index = 0;
            string commandType;

            if (regexParentheses.IsMatch(input))
            {
                index = input.IndexOf("(");
                commandType = input.Substring(0, index);

                command = cf.getCommand(main, commandType);
            }
            else if (main.currentCommand != null)
            {
                command = main.currentCommand;
            }
            else if (regexCommandOnly.IsMatch(input))
            {
                command = cf.getCommand(main, input);
            }
        }

        private void setCommandVariables()
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

        private void setVariablesFromInput(string input)
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

            if (regexVariables.IsMatch(input))
            {
                if (variables == null)
                    variables = new Dictionary<string, string>();

                string[] split = input.Split("=");
                variables.Add(split[0], split[1]);
            }

            setCommandVariables();
        }

        private void setCurrentCommand()
        {
            main.currentCommand = command;
            main.currentVariables = variables;
        }

        private void clearCurrentCommand()
        {
            main.currentCommand = null;
            main.currentVariables = null;
        }

        private void updateCommandUsage()
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
