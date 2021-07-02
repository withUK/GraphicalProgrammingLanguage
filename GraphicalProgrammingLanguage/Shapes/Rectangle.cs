using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Shapes
{
    class Rectangle : Shape
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
            g.DrawRectangle(p, x, y, width, length);
        }

        public override bool hasRequiredVariables()
        {
            return lengthSet && widthSet;
        }
        
        // Overrides
        public override void set(Dictionary<string, string> variables)
        {
            this.x = int.Parse(variables.GetValueOrDefault("x"));
            this.y = int.Parse(variables.GetValueOrDefault("y"));
            this.length = int.Parse(variables.GetValueOrDefault("length"));
            this.width = int.Parse(variables.GetValueOrDefault("width"));
            this.lineWeight = float.Parse(variables.GetValueOrDefault("lineWeight"));
            this.lineColor = Color.FromName(variables.GetValueOrDefault("lineColor"));
            this.fillColor = Color.FromName(variables.GetValueOrDefault("fillColor"));
        }

        // This overrides the base implemention of ToString() in this case this is now the Shape class.
        // Example output: 'StringRef 1, 2 : 3, 4'
        public override string ToString()
        {
            return base.ToString() + this.length + ", " + this.width;
        }
    }
}
