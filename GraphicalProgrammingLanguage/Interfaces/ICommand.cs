using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Interfaces
{
    interface ICommand
    {
        // Methods
        bool isValid(string command);

        void execute(string command);
    }
}
