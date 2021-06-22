using System;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Shapes
{
    class Rectangle : Shape
    {
        // Properties
        public int length { get; set; }
        public int width { get; set; }

        // Constructors
        public Rectangle() : base()
        {

        }

        public Rectangle(int x, int y, Color lineColor, Color fillColor, int lineWeight) : base(x, y, lineColor, fillColor, lineWeight)
        {
            this.length = length;
            this.width = width;
        }

        // Methods


        // Abstracts
        public override double calculateArea()
        {
            return length * width;
        }

        public override double calculatePerimeter()
        {
            return (2 * length) + (2 * width);
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(lineColor, lineWeight);
            SolidBrush b = new SolidBrush(fillColor);
            g.FillRectangle(b, x, y, width, length);
        }

        // Overrides
        // This overrides the base implemention of ToString() in this case this is now the Shape class.
        // Example output: 'StringRef 1, 2 : 3, 4'
        public override string ToString()
        {
            return base.ToString() + this.length + ", " + this.width;
        }
    }
}
