using GraphicalProgrammingLanguage.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphicalProgrammingLanguage.Commands
{
    class Clear : Command
    {
        // Constructors
        public Clear(MainGUI main) : base(main)
        {
            name = CommandTypes.clear.ToString();
        }

        // Overrides
        public override void execute()
        {
            if (isValid(new Dictionary<string, string>()))
            {
                log(main);
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
