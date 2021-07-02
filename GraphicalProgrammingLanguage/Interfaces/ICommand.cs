using System.Collections.Generic;

namespace GraphicalProgrammingLanguage.Interfaces
{
    interface ICommand
    {
        // Methods
        void set(Dictionary<string, string> variables);

        void execute();

        bool isValid(Dictionary<string, string> variables);

        void log(MainGUI main);
    }
}
