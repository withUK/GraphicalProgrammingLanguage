using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Commands
{
    class DrawTo : Command
    {
        // Constructors
        public DrawTo(MainGUI main) : base(main)
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
