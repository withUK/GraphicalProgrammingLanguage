using GraphicalProgrammingLanguage.Enums;
using System.Collections.Generic;

namespace GraphicalProgrammingLanguage.Commands
{
    class DrawTo : Command
    {
        // Properties
        protected int x { get; set; }
        private bool xSet { get; set; }
        protected int y { get; set; }
        private bool ySet { get; set; }

        // Constructors
        public DrawTo(MainGUI main) : base(main)
        {
            name = CommandTypes.drawto.ToString();
        }

        public DrawTo(MainGUI main, Dictionary<string,string>variables) : base(main, variables)
        {
            name = CommandTypes.drawto.ToString();
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
                main.dc.DrawLine(main.pen, main.x, main.y, x, y);
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
