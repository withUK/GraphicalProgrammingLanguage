using GraphicalProgrammingLanguage.Enums;
using GraphicalProgrammingLanguage.Factories;
using GraphicalProgrammingLanguage.Shapes;
using System;
using System.Collections.Generic;

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
                shape = factory.getShape(main, variables.GetValueOrDefault("type").ToString());
            }
        }

        // Methods
        public void set(Dictionary<string, string> variables)
        {
            this.variables = variables;
            if (variables.ContainsKey("type"))
            {
                shape = factory.getShape(main, variables.GetValueOrDefault("type"));
                shape.set(variables);
            }
        }

        // Abstracts
        public override void execute()
        {
            log(main);
            shape.draw(main.dc);
        }

        public override bool hasRequiredParameters()
        {
            if (shape != null)
            {
                return shape.hasRequiredVariables();
            }
            return false;
        }

        public override bool isValid(Dictionary<string, string> variables)
        {
            throw new NotImplementedException();
        }
    }
}
