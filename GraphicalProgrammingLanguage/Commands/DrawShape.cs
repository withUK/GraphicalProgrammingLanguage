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
        Graphics g { get; set; }
        ShapeFactory factory = new ShapeFactory();
        Shape shape { get; set; }

        // Constructors
        public DrawShape() : base()
        {

        }

        public DrawShape(string name, Dictionary<string, object> variables, Graphics g) : base(name, variables)
        {
            this.g = g;
            this.shape = factory.getShape(name);
        }

        // Methods
        public void set(string name, Dictionary<string, object> variables, Graphics g)
        {
            this.g = g;
            this.shape = factory.getShape(name);
        }

        // Abstracts
        public override void execute()
        {
            shape.draw(g);
        }

        public override bool validate()
        {
            throw new NotImplementedException();
        }
    }
}
