using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Shapes
{
    public class Rectangle : Shape
    {
        // Properties
        public int length { get; set; }
        private bool lengthSet { get; set; }
        public int width { get; set; }
        private bool widthSet { get; set; }

        // Constructors
        public Rectangle() : base()
        {

        }

        public Rectangle(MainGUI main) : base(main)
        {

        }

        public Rectangle(int x, int y, int length, int width, Color lineColor, Color fillColor, float lineWeight) : base(x, y, lineColor, fillColor, lineWeight)
        {
            Dictionary<string, string> variables = new Dictionary<string, string>();
            variables.Add("x", x.ToString());
            variables.Add("y", y.ToString());
            variables.Add("length", length.ToString());
            variables.Add("width", width.ToString());
            variables.Add("linecolor", lineColor.ToString());
            variables.Add("fillcolor", fillColor.ToString());
            variables.Add("lineweight", lineWeight.ToString());
            set(variables);
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
            g.DrawRectangle(p, x, y, width, length);
        }

        public override bool hasRequiredVariables()
        {
            return lengthSet && widthSet && xSet && ySet;
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
            if (variables.ContainsKey("length"))
            {
                length = int.Parse(variables.GetValueOrDefault("length"));
                lengthSet = true;
            }
            if (variables.ContainsKey("width"))
            {
                width = int.Parse(variables.GetValueOrDefault("width"));
                widthSet = true;
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

        // This overrides the base implemention of ToString() in this case this is now the Shape class.
        // Example output: 'StringRef 1, 2 : 3, 4'
        public override string ToString()
        {
            return base.ToString() + "length=" + this.length + ", width=" + this.width + ", perimeter=" + calculatePerimeter() + ", area=" + calculateArea();
        }
    }
}
