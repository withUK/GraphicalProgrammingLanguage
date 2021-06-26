using GraphicalProgrammingLanguage.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Commands
{
    class DrawTo : Command
    {
        // Properties
        protected int x { get; set; }
        protected int y { get; set; }

        // Constructors
        public DrawTo(MainGUI main) : base(main)
        {
            this.main = main;
            this.name = CommandTypes.drawTo.ToString();
        }

        public DrawTo(MainGUI main, Dictionary<string,string>variables) : base(main, variables)
        {
            this.main = main;
            this.name = CommandTypes.drawTo.ToString();
            this.variables = variables;
        }

        // Methods
        public void set(MainGUI main, Dictionary<string, string> variables)
        {
            this.main = main;
            this.variables = variables;
            this.x = int.Parse(variables.GetValueOrDefault("x"));
            this.y = int.Parse(variables.GetValueOrDefault("y"));
        }

        // Overrides
        public override void execute()
        {
            log(main);
            main.dc.DrawLine(main.pen, main.x, main.y, x, y);
            main.x = x;
            main.y = y;
        }

        public override bool validate()
        {
            throw new NotImplementedException();
        }
    }
}
