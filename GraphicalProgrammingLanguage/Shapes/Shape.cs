using GraphicalProgrammingLanguage.Interfaces;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Shapes
{
    abstract class Shape : IShape
    {
        // Properties
        protected int x { get; set; }
        protected int y { get; set; }

        protected int lineWeight;
        protected Color lineColor { get; set; }
        protected Color fillColor { get; set; }

        // Constructors
        public Shape()
        {

        }

        public Shape(int x, int y, Color lineColor, Color fillColor, int lineWeight)
        {
            this.x = x;
            this.y = y;
            this.lineWeight = lineWeight;
            this.lineColor = lineColor;
            this.fillColor = fillColor;
        }

        // Methods
        // The 'set' method uses the params in position [0] as x, [1] as y and [2] as the line weight.
        // This virtual method can be overwritten by children of this class that can be more specfic to the shape.
        public virtual void set(Dictionary<string, string> variables)
        {
            this.x = int.Parse(variables.GetValueOrDefault("x"));
            this.y = int.Parse(variables.GetValueOrDefault("y"));
            this.lineWeight = int.Parse(variables.GetValueOrDefault("lineWeight"));
            this.lineColor = Color.FromName(variables.GetValueOrDefault("lineColor"));
            this.fillColor = Color.FromName(variables.GetValueOrDefault("fillColor"));
        }

        // Abstracts
        // These methods have been brought in by the interface, as the class is abstract these methods are not reuqired at this level
        // and will be implemented by children of the Shape base class.
        public abstract double calculateArea();
        public abstract double calculatePerimeter();
        public abstract void draw(Graphics g);

        // Overrides
        // This overrides the base implemention of ToString() but combines with the x & y values.
        public override string ToString()
        {
            return base.ToString() + " " + this.x + ", " + this.y + " : ";
        }
    }
}
