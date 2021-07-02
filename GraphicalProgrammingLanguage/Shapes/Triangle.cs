using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GraphicalProgrammingLanguage.Shapes
{
    class Triangle : Shape
    {
        // Properties
        Point p1 { get; set; }
        private bool p1Set { get; set; }
        Point p2 { get; set; }
        private bool p2Set { get; set; }
        Point p3 { get; set; }
        private bool p3Set { get; set; }
        Point[] points { get; set; }

        // Constructors
        public Triangle(MainGUI main) : base(main)
        {

        }

        public Triangle(int x, int y, Color lineColor, Color fillColor, float lineWeight) : base(x, y, lineColor, fillColor, lineWeight)
        {
            
        }

        // Methods


        // Abstracts
        public override double calculateArea()
        {
            throw new NotImplementedException();
        }

        public override double calculatePerimeter()
        {
            throw new NotImplementedException();
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(lineColor, lineWeight);
            SolidBrush b = new SolidBrush(fillColor);
            
            g.FillPolygon(b, points);
            g.DrawPolygon(p, points);
        }

        public override bool hasRequiredVariables()
        {
            return p1Set && p2Set && p3Set;
        }

        // Overrides
        public override void set(Dictionary<string, string> variables)
        {
            this.x = int.Parse(variables.GetValueOrDefault("x"));
            this.y = int.Parse(variables.GetValueOrDefault("y"));
            this.lineWeight = float.Parse(variables.GetValueOrDefault("lineWeight"));
            this.lineColor = Color.FromName(variables.GetValueOrDefault("lineColor"));
            this.fillColor = Color.FromName(variables.GetValueOrDefault("fillColor"));

            p1 = new Point { X = int.Parse(variables.GetValueOrDefault("x1")), Y = int.Parse(variables.GetValueOrDefault("y1")) };
            p2 = new Point { X = int.Parse(variables.GetValueOrDefault("x2")), Y = int.Parse(variables.GetValueOrDefault("y2")) };
            p3 = new Point { X = int.Parse(variables.GetValueOrDefault("x3")), Y = int.Parse(variables.GetValueOrDefault("y3")) };

            points = new Point[3] { p1, p2, p3 };
        }
    }
}
