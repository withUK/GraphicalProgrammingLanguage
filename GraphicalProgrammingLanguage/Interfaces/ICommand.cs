using System.Collections.Generic;

namespace GraphicalProgrammingLanguage.Interfaces
{
    /// <summary>
    /// The command interface holds methods used for common actions relating to a generic command.
    /// </summary>
    interface ICommand
    {
        // Methods
        void set(Dictionary<string, string> variables);

        void execute();

        bool isValid(Dictionary<string, string> variables);

        void log(MainGUI main);
    }
}
