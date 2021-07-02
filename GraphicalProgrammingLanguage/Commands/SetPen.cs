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

        private bool colorSet { get; set; }
        private bool weightSet { get; set; }


        // Constructors
        public SetPen(MainGUI main) : base(main)
        {
            name = CommandTypes.setpen.ToString();
            pen = main.pen;
        }

        // Methods
        public void set(Dictionary<string, string> variables)
        {
            this.variables = variables;
            if (variables != null)
            {
                if (variables.ContainsKey("color"))
                {
                    colorSet = true;
                }
                if (variables.ContainsKey("weight"))
                {
                    weightSet = true;
                }
            }
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

        public override bool hasRequiredParameters()
        {
            if (weightSet || colorSet)
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
