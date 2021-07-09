using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Shapes
{
    public class Square : Shape
    {
        // Properties
        public int length { get; set; }
        private bool lengthSet { get; set; }

        // Constructors
        public Square() : base()
        {

        }

        public Square(MainGUI main) : base(main)
        {

        }

        public Square(int x, int y, int length, Color lineColor, Color fillColor, float lineWeight) : base(x, y, lineColor, fillColor, lineWeight)
        {
            Dictionary<string, string> variables = new Dictionary<string, string>();
            variables.Add("x", x.ToString());
            variables.Add("y", y.ToString());
            variables.Add("length", length.ToString());
            variables.Add("linecolor", lineColor.ToString());
            variables.Add("fillcolor", fillColor.ToString());
            variables.Add("lineweight", lineWeight.ToString());
            Set(variables);
        }

        // Methods


        // Abstracts
        public override double CalculateArea()
        {
            return length * length;
        }

        public override double CalculatePerimeter()
        {
            return length * 4;
        }

        public override void Draw(Graphics g)
        {
            Pen p = new Pen(lineColor, lineWeight);
            SolidBrush b = new SolidBrush(fillColor);
            g.FillRectangle(b, x, y, length, length);
            g.DrawRectangle(p, x, y, length, length);
        }

        public override bool HasRequiredVariables()
        {
            return lengthSet && xSet && ySet;
        }

        // Overrides
        public override void Set(Dictionary<string, string> variables)
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
        // Example output: 'StringRef 1, 2 : 3'
        public override string ToString()
        {
            return base.ToString() + "length=" + this.length + ", perimeter=" + CalculatePerimeter() + ", area=" + CalculateArea();
        }
    }
}
