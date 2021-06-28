﻿using System.Collections.Generic;

namespace GraphicalProgrammingLanguage.Interfaces
{
    interface ICommand
    {
        // Methods
        void set(MainGUI main, Dictionary<string, string> variables);

        void execute();

        bool validate();

        void log();

        void log(MainGUI main);
    }
}