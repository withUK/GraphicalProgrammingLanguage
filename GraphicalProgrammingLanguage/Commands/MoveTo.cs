using GraphicalProgrammingLanguage.Enums;
using System.Collections.Generic;

namespace GraphicalProgrammingLanguage.Commands
{
    class MoveTo : Command
    {
        // Properties
        protected int x { get; set; }
        private bool xSet { get; set; }
        protected int y { get; set; }
        private bool ySet { get; set; }

        // Constructors
        public MoveTo(MainGUI main) : base(main)
        {
            name = CommandTypes.moveto.ToString();
        }

        public MoveTo(MainGUI main, Dictionary<string, string> variables) : base(main, variables)
        {
            name = CommandTypes.moveto.ToString();
        }

        // Methods
        public void set(Dictionary<string, string> variables)
        {
            this.variables = variables;
            if (variables != null)
            {
                if (variables.ContainsKey("x"))
                {
                    x = int.Parse(variables.GetValueOrDefault("x"));
                    xSet = true;
                }
                if (variables.ContainsKey("y"))
                {
                    y = int.Parse(variables.GetValueOrDefault("y"));
                    ySet = true;
                }
            }
        }

        // Overrides
        public override void execute()
        {
            if (isValid(variables))
            {
                log(main);
                main.x = x;
                main.y = y;
            }
        }

        public override bool hasRequiredParameters()
        {
            if (xSet && ySet)
            {
                return true;
            }
            return false;
        }

        public override bool isValid(Dictionary<string, string> variables)
        {
            return hasRequiredParameters();
        }
    }
}
