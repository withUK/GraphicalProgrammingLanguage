using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Shapes
{
    public class Circle : Shape
    {
        // Properties
        public int radius { get; set; }
        private bool radiusSet { get; set; }

        // Constructors
        public Circle() : base() { }

        public Circle(MainGUI main) : base(main) { }

        public Circle(int x, int y, int radius, Color lineColor, Color fillColor, float lineWeight) : base(x, y, lineColor, fillColor, lineWeight)
        {
            Dictionary<string, string> variables = new Dictionary<string, string>();
            variables.Add("x", x.ToString());
            variables.Add("y", y.ToString());
            variables.Add("radius", radius.ToString());
            variables.Add("linecolor", lineColor.ToString());
            variables.Add("fillcolor", fillColor.ToString());
            variables.Add("lineweight", lineWeight.ToString());
            set(variables);
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
            return radiusSet && xSet && ySet;
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
            if (variables.ContainsKey("lineweight"))
            {
                lineWeight = float.Parse(variables.GetValueOrDefault("lineweight"));
            }
            if (variables.ContainsKey("linecolor"))
            {
                lineColor = Color.FromName(variables.GetValueOrDefault("linecolor"));
            }
            if (variables.ContainsKey("fillcolor"))
            {
                fillColor = Color.FromName(variables.GetValueOrDefault("fillcolor"));
            }
        }

        /// <summary>
        /// This overrides the base implemention of ToString() in this case this is now the Shape class.
        /// </summary>
        /// <returns>Example output: 'StringRef x=1, y=2 : radius=3, perimeter=4, area=5'</returns>
        public override string ToString()
        {
            return base.ToString() + "radius=" + this.radius + ", perimeter=" + calculatePerimeter() + ", area=" + calculateArea();
        }
    }
}
