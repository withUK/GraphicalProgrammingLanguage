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
            this.main = main;
            this.name = CommandTypes.drawshape.ToString();
        }

        public DrawShape(MainGUI main, Dictionary<string, string> variables) : base(main, variables)
        {
            this.main = main;
            this.name = CommandTypes.drawshape.ToString();
            this.variables = variables;
            this.shape = factory.getShape(variables.GetValueOrDefault("type").ToString());
        }

        // Methods
        public void set(MainGUI main, Dictionary<string, string> variables)
        {
            this.main = main;
            this.variables = variables;
            this.shape = factory.getShape(variables.GetValueOrDefault("type").ToString());
            this.shape.set(variables);
        }

        // Abstracts
        public override void execute()
        {
            log(main);
            shape.draw(main.dc);
        }

        public override bool validate()
        {
            throw new NotImplementedException();
        }
    }
}
