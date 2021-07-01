using GraphicalProgrammingLanguage.Enums;
using System.Collections.Generic;

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
            if (variables.ContainsKey("x"))
            {
                x = int.Parse(variables.GetValueOrDefault("x"));
            }
            if (variables.ContainsKey("y"))
            {
                y = int.Parse(variables.GetValueOrDefault("y"));
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

        public override bool isValid(Dictionary<string, string> variables)
        {
            if (variables.ContainsKey("x") && variables.ContainsKey("y"))
            {
                return true;
            }
            return false;
        }
    }
}
