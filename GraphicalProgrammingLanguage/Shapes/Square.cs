using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GraphicalProgrammingLanguage.Shapes
{
    class Square : Shape
    {
        // Properties
        public int length { get; set; }

        // Constructors
        public Square() : base()
        {

        }

        public Square(int x, int y, Color lineColor, Color fillColor, int lineWeight) : base(x, y, lineColor, fillColor, lineWeight)
        {
            this.length = length;
        }

        // Abstracts
        public override double calculateArea()
        {
            return length * length;
        }

        public override double calculatePerimeter()
        {
            return length * 4;
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(lineColor, lineWeight);
            SolidBrush b = new SolidBrush(fillColor);
            g.FillRectangle(b, x, y, length, length);
        }

        // Overrides
        // This overrides the base implemention of ToString() in this case this is now the Shape class.
        // Example output: 'StringRef 1, 2 : 3'
        public override string ToString()
        {
            return base.ToString() + this.length;
        }
    }
}
