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
        private const string REG_VARIABLE = "^var\\s[a-zA-Z]+=[a-zA-Z0-9\\/+*-]+$";
        private const string REG_METHOD = "^method\\s[a-zA-Z]+\\([a-zA-Z0-9,;]+\\)$";
        private const string REG_SCRIPT_COMMAND = "^[a-zA-Z]+\\s[a-zA-Z0-9=<>\\s]+$";
        private const string REG_SCRIPT_IFSTATEMENT = "^if\\s[a-zA-Z]+=[a-zA-Z0-9]+$";
        private const string REG_SCRIPT_IFSTATEMENT_PARENTHESIS = "^if\\([a-zA-Z0-9]+[=<>]+[a-zA-Z0-9]+\\)$";
        private const string REG_SCRIPT_WHILESTATEMENT = "^while\\s[a-zA-Z]+=[a-zA-Z0-9]+$";
        private const string REG_SCRIPT_WHILESTATEMENT_PARENTHESIS = "^while\\([a-zA-Z0-9]+[=<>]+[a-zA-Z0-9]+\\)$";
        private const string REG_SCRIPT_FORSTATEMENT = "^for\\s[a-zA-Z]+=[a-zA-Z0-9]+$";
        private const string REG_SCRIPT_FORSTATEMENT_PARENTHESIS = "^for\\s[a-zA-Z]+=[a-zA-Z0-9]+$";
        private const string REG_PARENTHESES = "^[a-zA-Z]+\\([^)]*\\)$";
        private const string REG_COMMAND_ONLY = "^[a-zA-Z]+$";
        private const string REG_VARIABLE_IND = "^[a-zA-Z]+=[a-zA-Z0-9]+$";
        private const string REG_VARIABLE_POINT = "^[a-zA-Z0-9]+=[0-9]+,[0-9]+$";
        private const string REG_MATH = "^[\\/*\\-+]+$";

        private const string REG_NUMBER = "^[0-9]+$";
        private const string REG_STRING = "^[a-zA-Z]+$";

        Regex regexVariable = new Regex(REG_VARIABLE, RegexOptions.IgnoreCase);
        Regex regexMethod = new Regex(REG_METHOD, RegexOptions.IgnoreCase);
        Regex regexScriptCommand = new Regex(REG_SCRIPT_COMMAND, RegexOptions.IgnoreCase);
        Regex regexIfStatement = new Regex(REG_SCRIPT_IFSTATEMENT, RegexOptions.IgnoreCase);
        Regex regexIfParenthesisStatement = new Regex(REG_SCRIPT_IFSTATEMENT_PARENTHESIS, RegexOptions.IgnoreCase);
        Regex regexWhileStatement = new Regex(REG_SCRIPT_WHILESTATEMENT, RegexOptions.IgnoreCase);
        Regex regexWhileParenthesisStatement = new Regex(REG_SCRIPT_WHILESTATEMENT_PARENTHESIS, RegexOptions.IgnoreCase);
        Regex regexForStatement = new Regex(REG_SCRIPT_FORSTATEMENT, RegexOptions.IgnoreCase);
        Regex regexForParenthesisStatement = new Regex(REG_SCRIPT_FORSTATEMENT_PARENTHESIS, RegexOptions.IgnoreCase);
        Regex regexParentheses = new Regex(REG_PARENTHESES, RegexOptions.IgnoreCase);
        Regex regexCommandOnly = new Regex(REG_COMMAND_ONLY, RegexOptions.IgnoreCase);
        Regex regexVariables = new Regex(REG_VARIABLE_IND, RegexOptions.IgnoreCase);
        Regex regexVariablesPoint = new Regex(REG_VARIABLE_POINT, RegexOptions.IgnoreCase);
        Regex regexMath = new Regex(REG_MATH, RegexOptions.IgnoreCase);

        Regex regexNumber = new Regex(REG_NUMBER, RegexOptions.IgnoreCase);
        Regex regexString = new Regex(REG_STRING, RegexOptions.IgnoreCase);

        // Properties
        private MainGUI main { get; set; }
        private List<string> scriptLines { get; set; }
        private string[] scriptArray { get; set; }
        private CommandParser cp { get; set; }
        private CommandFactory cf = new CommandFactory();
        private Command command { get; set; }
        private Dictionary<string, string> variables = new Dictionary<string, string>();

        // Constructor
        public ScriptParser(MainGUI main)
        {
            this.main = main;
            cp = new CommandParser(main);
        }

        // Methods
        public void ExecuteScript(string input)
        {
            PopulateScriptList(input);
            ParseScript();
        }

        private void PopulateScriptList(string input)
        {
            scriptLines = new List<string>();

            foreach (var line in main.txtScript.Lines)
            {
                scriptLines.Add(line);
            }
        }

        private void ParseScript()
        {
            scriptArray = scriptLines.GetRange(0, scriptLines.Count).ToArray();

            for (int i = 0; i < scriptArray.Length; i++)
            {
                var thisLine = scriptArray[i];

                if (regexIfParenthesisStatement.IsMatch(thisLine) || regexIfStatement.IsMatch(thisLine))
                {
                    i = ParseStatements(i, thisLine);
                }
                else if(regexForParenthesisStatement.IsMatch(thisLine) || regexForStatement.IsMatch(thisLine))
                {
                    i = ParseStatements(i, thisLine);
                }
                else if(regexWhileParenthesisStatement.IsMatch(thisLine) || regexWhileStatement.IsMatch(thisLine))
                {
                    i = ParseStatements(i, thisLine);
                }
                else if (regexParentheses.IsMatch(thisLine))
                {
                    Command c = GetCommand(thisLine);
                    c.main = TakeSnapshotOfMain(c);
                    c.Execute();
                }
                else if (regexVariable.IsMatch(thisLine))
                {
                    thisLine = thisLine.Replace("var", "");
                    thisLine = thisLine.Trim();
                    string[] split = thisLine.Split("=");
                    if (variables.ContainsKey(split[0]))
                    {
                        variables[split[0]] = split[1];
                    }
                    else
                    {
                        variables.Add(split[0], split[1]);
                    }
                }
                else if (regexMethod.IsMatch(thisLine))
                {

                }
            }
        }

        private int ParseStatements(int i, string thisLine)
        {
            List<Command> commands = new List<Command>();
            List<string> contents = new List<string>();
            
            if (thisLine.StartsWith("if"))
            {
                int order = 1;
                int beginIndex = i;
                i++;

                var currentLine = scriptArray[i];

                while (currentLine != "endif")
                {
                    Command c = GetCommand(currentLine);
                    c.order = order;
                    c.main = TakeSnapshotOfMain(c);

                    commands.Add(c);
                    i++;
                    order++;
                    currentLine = scriptArray[i];
                }

                if (ParseCondition(scriptArray[beginIndex]))
                {
                    ExecuteCommands(commands);
                }
            }
            else if (thisLine.StartsWith("while"))
            {
                int order = 1;
                int beginIndex = i;
                i++;

                var currentLine = scriptArray[i];

                while (currentLine != "endwhile")
                {
                    if (regexVariable.IsMatch(currentLine))
                    {
                        currentLine = SubstitueVariables(currentLine);
                    }
                    Command c = GetCommand(currentLine);
                    c.order = order;
                    c.main = TakeSnapshotOfMain(c);

                    commands.Add(c);
                    i++;
                    order++;
                    currentLine = scriptArray[i];
                }

                while (ParseCondition(scriptArray[beginIndex]))
                {
                    ExecuteCommands(commands);
                }
            }
            else
            {
                Dictionary<string, string> commandVariables = cp.SetVariablesFromInput(thisLine);
                var command = cf.GetCommand(main, thisLine);
                command.Set(commandVariables);
            }

            return i;
        }

        private string SubstitueVariables(string input)
        {
            var inputStripped = input.Replace("var", "").Trim();
            string[] split = input.Split("=");

            string delimter = null;

            if (split[1].Contains("+"))
                delimter = "+";
            if (split[1].Contains("-"))
                delimter = "-";
            if (split[1].Contains("*"))
                delimter = "*";
            if (split[1].Contains("/"))
                delimter = "/";

            if (split[1].Contains(delimter))
            {
                string[] fSplit = split[1].Split(delimter);
                if (this.variables.ContainsKey(fSplit[0]))
                {
                    fSplit[0] = this.variables.GetValueOrDefault(fSplit[0]);
                }
                if (this.variables.ContainsKey(fSplit[1]))
                {
                    fSplit[1] = this.variables.GetValueOrDefault(fSplit[1]);
                }

                var result = 0;

                if (split[1].Contains("+"))
                    result = int.Parse(fSplit[1]) + int.Parse(fSplit[1]);
                if (split[1].Contains("-"))
                    result = int.Parse(fSplit[1]) - int.Parse(fSplit[1]);
                if (split[1].Contains("*"))
                    result = int.Parse(fSplit[1]) * int.Parse(fSplit[1]);
                if (split[1].Contains("/"))
                    result = int.Parse(fSplit[1]) / int.Parse(fSplit[1]);

                input = input.Replace(split[1], result.ToString());
            }
            else if (this.variables.ContainsKey(split[1]))
            {
                var replace = this.variables.GetValueOrDefault(split[0]);
                input = input.Replace(split[1], replace);
            }
            
            return input;
        }

        private static void ExecuteCommands(List<Command> commands)
        {
            foreach (var item in commands)
            {
                item.Execute();
            }
        }

        private MainGUI TakeSnapshotOfMain(Command c)
        {
            MainGUI snapshotOFMain = main;
            snapshotOFMain = c.main;
            snapshotOFMain.currentCommand = c;
            snapshotOFMain.currentCommand.Execute();
            snapshotOFMain.currentCommand = null;

            return snapshotOFMain;
        }

        private bool ParseCondition(string input)
        {
            int startIndex = input.IndexOf("(");
            int endIndex = input.IndexOf(")");
            string delimiter = null;

            float ci1 = 0;
            float ci2 = 0;
            string cs1 = null;
            string cs2 = null;
            bool ci1Set = false;
            bool ci2Set = false;
            bool cs1Set = false;
            bool cs2Set = false;
            
            string conditionString = input.Substring(startIndex + 1, endIndex - startIndex - 1);

            if (conditionString.Contains("="))
                delimiter = "=";
            else if (conditionString.Contains("<"))
                delimiter = "<";
            else if (conditionString.Contains(">"))
                delimiter = ">";

            string[] split = conditionString.Split(delimiter);

            if (regexNumber.IsMatch(split[0]))
            {
                ci1 = float.Parse(split[0]);
                ci1Set = true;
            }
            else
            {
                if (variables.ContainsKey(split[0]))
                {
                    var v = variables.GetValueOrDefault(split[0]);
                    if (regexNumber.IsMatch(v))
                    {
                        ci1 = float.Parse(v);
                        ci1Set = true;
                    }
                    else
                    {
                        cs1 = v;
                        cs1Set = true;
                    }
                }
                else
                {
                    cs1 = split[0];
                    cs1Set = true;
                }
            }

            if (regexNumber.IsMatch(split[1]))
            {
                ci2 = float.Parse(split[1]);
                ci2Set = true;
            }
            else
            {
                if (variables.ContainsKey(split[1]))
                {
                    var v = variables.GetValueOrDefault(split[1]);
                    if (regexNumber.IsMatch(v))
                    {
                        ci2 = float.Parse(v);
                        ci2Set = true;
                    }
                    else
                    {
                        cs2 = v;
                        cs2Set = true;
                    }
                }
                else
                {
                    cs2 = split[0];
                    cs2Set = true;
                }
            }

            switch (delimiter)
            {
                case "=":
                    if (ci1Set && ci2Set)
                    {
                        return ci1 == ci2;
                    }
                    if (cs1Set && cs2Set)
                    {
                        return ci1.Equals(ci2);
                    }
                    if ((ci1Set && cs2Set) || (ci2Set && cs1Set))
                    {
                        throw new Exception("Variables of different data types cannot be compared.");
                    }
                    break;
                case "<":
                    if (ci1Set && ci2Set)
                    {
                        return ci1 < ci2;
                    }
                    if (cs1Set && cs2Set)
                    {
                        throw new Exception("String variables cannot be evaluated by less than.");
                    }
                    if ((ci1Set && cs2Set) || (ci2Set && cs1Set))
                    {
                        throw new Exception("Variables of different data types cannot be compared.");
                    }
                    break;
                case ">":
                    if (ci1Set && ci2Set)
                    {
                        return ci1 > ci2;
                    }
                    if (cs1Set && cs2Set)
                    {
                        throw new Exception("String variables cannot be evaluated by greateer than.");
                    }
                    if ((ci1Set && cs2Set) || (ci2Set && cs1Set))
                    {
                        throw new Exception("Variables of different data types cannot be compared.");
                    }
                    break;
                default:
                    throw new Exception("Comparitor not recognised.");
            }

            return false;
        }

        private Command GetCommand(string input)
        {
            int index = 0;
            string commandType;
            
            if (regexParentheses.IsMatch(input))
            {
                index = input.IndexOf("(");
                commandType = input.Substring(0, index);

                command = cf.GetCommand(main, commandType);
            }
            else if (regexCommandOnly.IsMatch(input))
            {
                command = cf.GetCommand(main, input);
            }

            command = SetVariablesFromInput(command, input);

            return command;
        }

        private Command SetVariablesFromInput(Command command, string input)
        {
            Dictionary<string, string> variables = new Dictionary<string, string>();
            int startIndex = 0;
            int endIndex = 0;

            float ci1 = 0;
            float ci2 = 0;
            string cs1 = null;
            string cs2 = null;
            bool ci1Set = false;
            bool ci2Set = false;
            bool cs1Set = false;
            bool cs2Set = false;

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
                        
                        if (this.variables.ContainsKey(sp[1]))
                        {
                            sp[1] = this.variables.GetValueOrDefault(sp[1]);
                        }

                        variables.Add(sp[0], sp[1]);
                    }
                }
            }
            else if (main.currentCommand != null)
            {
                variables = main.currentVariables;
            }

            if (regexVariables.IsMatch(input) || regexVariablesPoint.IsMatch(input) || regexVariable.IsMatch(input))
            {
                if (this.variables == null)
                    this.variables = new Dictionary<string, string>();

                string[] sp = input.Split("=");

                if (regexVariable.IsMatch(input))
                {
                    string delimiter = ""; 
                    sp[0] = sp[0].Replace("var", "").Trim();

                    if (sp[1].Contains("+"))
                        delimiter = "+";
                    if (sp[1].Contains("-"))
                        delimiter = "-";
                    if (sp[1].Contains("*"))
                        delimiter = "*";
                    if (sp[1].Contains("/"))
                        delimiter = "/";

                    string[] inlineSp = sp[1].Split(delimiter);

                    if (this.variables.ContainsKey(inlineSp[0]))
                    {
                        inlineSp[0] = this.variables.GetValueOrDefault(inlineSp[0]);
                    }
                    if (inlineSp.Length == 2)
                    {
                        if (this.variables.ContainsKey(inlineSp[1]))
                        {
                            inlineSp[1] = this.variables.GetValueOrDefault(inlineSp[1]);
                        }

                        if (regexNumber.IsMatch(inlineSp[0]) && regexNumber.IsMatch(inlineSp[1]))
                        {
                            float x = 0;
                            switch (delimiter)
                            {
                                case "+":
                                    x = float.Parse(inlineSp[0]) + float.Parse(inlineSp[1]);
                                    break;
                                case "-":
                                    x = float.Parse(inlineSp[0]) - float.Parse(inlineSp[1]);
                                    break;
                                case "*":
                                    x = float.Parse(inlineSp[0]) * float.Parse(inlineSp[1]);
                                    break;
                                case "/":
                                    x = float.Parse(inlineSp[0]) / float.Parse(inlineSp[1]);
                                    break;
                                default:
                                    break;
                            }

                            sp[1] = x.ToString();
                        }
                    }

                }

                if (this.variables.ContainsKey(sp[1]))
                {
                    sp[1] = this.variables.GetValueOrDefault(sp[1]);
                }

                if (!this.variables.ContainsKey(sp[0]))
                {
                    this.variables.Add(sp[0], sp[1]);
                }
                else
                {
                    this.variables[sp[0]] = sp[1];
                }
            }

            if (true)
            {

            }

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

            return command;
        }
    }
}
