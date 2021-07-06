using GraphicalProgrammingLanguage.Enums;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Commands
{
    class SetFill : Command
    {
        // Properties
        protected Brush brush;
        
        // Constructors
        public SetFill(MainGUI main) : base(main)
        {
            name = CommandTypes.setfill.ToString();
            brush = main.brush;
        }

        // Methods
        public void set(Dictionary<string, string> variables)
        {
            this.variables = variables;
            if (variables != null)
            {
                if (variables.ContainsKey("color"))
                {
                    brush = new SolidBrush(Color.FromName(variables.GetValueOrDefault("color")));
                }
                else
                {
                    brush = new SolidBrush(Color.Transparent);
                }
            }
        }

        // Overrides
        public override void execute()
        {
            if (isValid(variables))
            {
                log(main);
                main.brush = brush;
            }
        }

        public override bool hasRequiredParameters()
        {
            return true;
        }

        public override bool isValid(Dictionary<string, string> variables)
        {
            return hasRequiredParameters();
        }
    }
}
