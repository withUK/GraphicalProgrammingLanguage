using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Shapes
{
    class Circle : Shape
    {
        // Properties
        public int radius { get; set; }
        private bool radiusSet { get; set; }

        // Constructors
        public Circle() : base()
        {

        }

        public Circle(MainGUI main) : base(main)
        {

        }

        public Circle(int x, int y, int radius, Color lineColor, Color fillColor, float lineWeight) : base(x, y, lineColor, fillColor, lineWeight)
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

        public override bool hasRequiredVariables()
        {
            return radiusSet && xSet & ySet;
        }

        // Overrides
        public override void set(Dictionary<string, string> variables)
        {
            if (variables.ContainsKey("x"))
            {
                x = int.Parse(variables.GetValueOrDefault("x"));
                xSet = true;
            }
            if (variables.ContainsKey("y"))
            {
                y = int.Parse(variables.GetValueOrDefault("y"));
                ySet = true;
            }
            if (variables.ContainsKey("radius"))
            {
                radius = int.Parse(variables.GetValueOrDefault("radius"));
                radiusSet = true;
            }
            if (variables.ContainsKey("lineWeight"))
            {
                lineWeight = float.Parse(variables.GetValueOrDefault("lineWeight"));
            }
            if (variables.ContainsKey("lineColor"))
            {
                lineColor = Color.FromName(variables.GetValueOrDefault("lineColor"));
            }
            if (variables.ContainsKey("fillCOlor"))
            {
                fillColor = Color.FromName(variables.GetValueOrDefault("fillColor"));
            }
        }

        // This overrides the base implemention of ToString() in this case this is now the Shape class.
        // Example output: 'StringRef 1, 2 : 3'
        public override string ToString()
        {
            return base.ToString() + this.radius;
        }
    }
}
