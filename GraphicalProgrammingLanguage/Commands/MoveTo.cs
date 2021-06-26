using GraphicalProgrammingLanguage.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicalProgrammingLanguage.Commands
{
    class MoveTo : Command
    {
        // Properties
        protected int x { get; set; }
        protected int y { get; set; }

        // Constructors
        public MoveTo(MainGUI main) : base(main)
        {
            this.main = main;
            this.name = CommandTypes.moveTo.ToString();
        }

        public MoveTo(MainGUI main, Dictionary<string, string> variables) : base(main, variables)
        {
            this.main = main;
            this.name = CommandTypes.moveTo.ToString();
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
            main.x = x;
            main.y = y;
        }

        public override bool validate()
        {
            throw new NotImplementedException();
        }
    }
}
