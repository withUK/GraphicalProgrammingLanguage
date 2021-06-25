using GraphicalProgrammingLanguage.Interfaces;
using System.Collections.Generic;

namespace GraphicalProgrammingLanguage.Commands
{
    abstract class Command : ICommand
    {
        // Properties
        protected string name { get; set; }
        protected Dictionary<string,object> variables { get; set; }

        // Constructors
        public Command()
        {

        }

        public Command(string name, Dictionary<string, object> variables)
        {
            this.name = name;
            this.variables = variables;
        }

        // Methods
        public void set(string name, Dictionary<string, object> variables)
        {
            this.name = name;
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
