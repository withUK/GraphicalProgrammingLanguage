using System;
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

        public override bool isValid()
        {
            throw new NotImplementedException();
        }
    }
}
