using System.Collections.Generic;

namespace GraphicalProgrammingLanguage.Interfaces
{
    interface ICommand
    {
        // Methods
        void set(string name, Dictionary<string, object> variables);

        void execute();

        bool validate();

        void log();
    }
}
