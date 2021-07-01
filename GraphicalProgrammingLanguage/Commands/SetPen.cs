using GraphicalProgrammingLanguage.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GraphicalProgrammingLanguage.Commands
{
    class SetPen : Command
    {
        // Properties
        protected Pen pen;
        private float weight;

        // Constructors
        public SetPen(MainGUI main) : base(main)
        {
            name = CommandTypes.setpen.ToString();
            pen = main.pen;
        }

        // Methods
        public void set(MainGUI main, Dictionary<string, string> variables)
        {
            this.variables = variables;
        }

        // Overrides
        public override void execute()
        {
            if (isValid(variables))
            {
                log(main);
                if (variables.ContainsKey("color"))
                {
                    pen.Color = Color.FromName(variables.GetValueOrDefault("color"));
                }
                if (variables.ContainsKey("weight"))
                {
                    pen.Width = weight;
                }
            }
        }

        public override bool isValid(Dictionary<string, string> variables)
        {
            if (variables.ContainsKey("weight"))
            {
                bool success = float.TryParse(variables.GetValueOrDefault("weight"), out weight);
                return success;
            }
            return true;
        }
    }
}
