using GraphicalProgrammingLanguage.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GraphicalProgrammingLanguage.Commands
{
    class Reset : Command
    {
        // Constructors
        public Reset(MainGUI main) : base(main)
        {
            name = CommandTypes.reset.ToString();
        }

        // Overrides
        public override void execute()
        {
            if (isValid(new Dictionary<string, string>()))
            {
                log(main);
                main.x = 0;
                main.y = 0;
                main.dc.Clear(Color.Gainsboro);
            }
        }

        public override bool hasRequiredParameters()
        {
            return true;
        }

        public override bool isValid(Dictionary<string, string> variables)
        {
            return true;
        }
    }
}
