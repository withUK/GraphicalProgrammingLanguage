using System.Collections.Generic;

namespace GraphicalProgrammingLanguage.Interfaces
{
    /// <summary>
    /// The command interface holds methods used for common actions relating to a generic command.
    /// </summary>
    interface ICommand
    {
        // Methods
        void Set(Dictionary<string, string> variables);

        void Execute();

        bool IsValid(Dictionary<string, string> variables);

        void Log(MainGUI main);
    }
}
