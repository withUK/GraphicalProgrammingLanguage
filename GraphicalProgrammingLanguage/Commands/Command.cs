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

        // Abstracts
        public abstract bool isValid(string command);
        public abstract void execute(string command);
    }
}
