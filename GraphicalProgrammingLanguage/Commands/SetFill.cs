﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Commands
{
    class SetFill : Command
    {
        // Constructors
        public SetFill(MainGUI main) : base(main)
        {
            this.main = main;
        }

        public override void execute()
        {
            throw new NotImplementedException();
        }

        public override bool hasRequiredParameters()
        {
            return true;
        }

        public override bool isValid(Dictionary<string, string> variables)
        {
            throw new NotImplementedException();
        }
    }
}
