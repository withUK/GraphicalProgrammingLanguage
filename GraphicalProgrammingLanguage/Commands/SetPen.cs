using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Commands
{
    class SetPen : Command
    {
        // Constructors
        public SetPen(MainGUI main) : base(main)
        {
            this.main = main;
        }

        public override void execute()
        {
            throw new NotImplementedException();
        }

        public override bool validate()
        {
            throw new NotImplementedException();
        }
    }
}
