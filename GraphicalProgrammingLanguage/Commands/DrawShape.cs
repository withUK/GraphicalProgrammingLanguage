using GraphicalProgrammingLanguage.Enums;
using GraphicalProgrammingLanguage.Factories;
using GraphicalProgrammingLanguage.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Commands
{
    class DrawShape : Command
    {
        // Properties
        protected ShapeFactory factory = new ShapeFactory();
        protected Shape shape { get; set; }

        // Constructors
        public DrawShape(MainGUI main) : base(main)
        {
            name = CommandTypes.drawshape.ToString();
        }

        public DrawShape(MainGUI main, Dictionary<string, string> variables) : base(main, variables)
        {
            name = CommandTypes.drawshape.ToString();
            if (variables.ContainsKey("type"))
            {
                shape = factory.getShape(variables.GetValueOrDefault("type").ToString());
            }
        }

        // Methods
        public void set(Dictionary<string, string> variables)
        {
            this.variables = variables;
            shape.set(variables);
        }

        // Abstracts
        public override void execute()
        {
            log(main);
            shape.draw(main.dc);
        }

        public override bool isValid(Dictionary<string, string> variables)
        {
            throw new NotImplementedException();
        }
    }
}
