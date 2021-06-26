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
            this.main = main;
            this.name = CommandTypes.reset.ToString();
        }

        // Methods
        public void set(MainGUI main, Dictionary<string, string> variables)
        {
            this.main = main;
            this.variables = variables;
        }

        // Overrides
        public override void execute()
        {
            log(main);
            main.x = 0;
            main.y = 0;
            main.dc.Clear(Color.Gainsboro);
        }

        public override bool validate()
        {
            throw new NotImplementedException();
        }
    }
}
