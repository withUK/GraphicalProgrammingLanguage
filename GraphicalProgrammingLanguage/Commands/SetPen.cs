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

        // Constructors
        public SetPen(MainGUI main) : base(main)
        {
            this.main = main;
            this.name = CommandTypes.setPen.ToString();
            pen = main.pen;
        }

        // Methods
        public void set(MainGUI main, Dictionary<string, string> variables)
        {
            this.main = main;
            this.variables = variables;
            pen = main.pen;
        }

        // Overrides
        public override void execute()
        {
            log(main);
            if (variables.ContainsKey("color"))
            {
                pen.Color = Color.FromName(variables.GetValueOrDefault("color"));
            }
            if (variables.ContainsKey("weight"))
            {
                pen.Width = float.Parse(variables.GetValueOrDefault("weight"));
            }

        }

        public override bool validate()
        {
            throw new NotImplementedException();
        }
    }
}
