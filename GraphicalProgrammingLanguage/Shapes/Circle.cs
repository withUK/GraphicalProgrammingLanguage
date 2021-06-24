using System;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Shapes
{
    class Circle : Shape
    {
        // Properties
        public int radius { get; set; }

        // Constructors
        public Circle() : base()
        {

        }

        public Circle(int x, int y, int radius, Color lineColor, Color fillColor, int lineWeight) : base(x, y, lineColor, fillColor, lineWeight)
        {   
            this.radius = radius;
        }

        // Methods


        // Abstracts
        public override double calculateArea()
        {
            return Math.PI * (radius ^ 2);
        }

        public override double calculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(lineColor, lineWeight);
            SolidBrush b = new SolidBrush(fillColor);
            g.FillEllipse(b, x, y, radius * 2, radius * 2);
            g.DrawEllipse(p, x, y, radius * 2, radius * 2);
        }

        // Overrides
        public override void set(Color lineColor, Color fillColor, params int[] list)
        {
            this.lineColor = lineColor;
            this.fillColor = fillColor;

            if (list.Length > 1)
                this.x = list[0];

            if (list.Length > 2)
                this.y = list[1];

            if (list.Length > 3)
                this.lineWeight = list[2];

            if (list.Length == 4)
                this.radius = list[3];
        }

        // This overrides the base implemention of ToString() in this case this is now the Shape class.
        // Example output: 'StringRef 1, 2 : 3'
        public override string ToString()
        {
            return base.ToString() + this.radius;
        }        
    }
}
