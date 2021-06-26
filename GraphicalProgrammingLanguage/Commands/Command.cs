using GraphicalProgrammingLanguage.Interfaces;
using System.Collections.Generic;

namespace GraphicalProgrammingLanguage.Commands
{
    abstract class Command : ICommand
    {
        // Properties
        protected MainGUI main { get; set; }
        protected string name { get; set; }
        protected Dictionary<string,string> variables { get; set; }

        // Constructors
        public Command(MainGUI main)
        {
            this.main = main;
        }

        public Command(MainGUI main, Dictionary<string, string> variables)
        {
            this.main = main;
            this.variables = variables;
        }

        // Methods
        public void set(MainGUI main, Dictionary<string, string> variables)
        {
            this.main = main;
            this.variables = variables;
        }

        public void log()
        {
            Logger.Log($"Command {name} called.");
        }

        // Abstracts
        public abstract void execute();
        public abstract bool validate();
    }
}
