using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Shapes
{
    public class Rectangle : Shape
    {
        #region/ Properties
        public int length { get; set; }
        private bool lengthSet { get; set; }
        public int width { get; set; }
        private bool widthSet { get; set; }
        #endregion

        #region Constructors
        public Rectangle() : base()
        {

        }

        public Rectangle(MainGUI main) : base(main)
        {

        }

        /// <summary>
        /// This constructor is passed all the variables required to action the draw method following instantiation.
        /// </summary>
        /// <param name="x">Horizontal coordinate of the pen.</param>
        /// <param name="y">Verticle coordinate of the pen.</param>
        /// <param name="length">The value of the length of the rectangle as an integer.</param>
        /// <param name="width">The value of the width of the rectangle as an integer.</param>
        /// <param name="lineColor">The string value of a color for the line.</param>
        /// <param name="fillColor">The string value of a color for the fill.</param>
        /// <param name="lineWeight">The width of the line.</param>
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
            Set(variables);
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Calculates the area of the created shape using the given length and width properties.
        /// </summary>
        /// <returns>The calulated value of the area in an unrestricted decimal format.</returns>
        public override double CalculateArea()
        {
            return length * width;
        }

        /// <summary>
        /// Calculates the perimeter of the created shape using the given length and width properties.
        /// </summary>
        /// <returns>The calulated value of the perimeter in an unrestricted decimal format.</returns>
        public override double CalculatePerimeter()
        {
            return (2 * length) + (2 * width);
        }

        /// <summary>
        /// The action that adds the specified shape the MainGUI graphic object.
        /// </summary>
        /// <param name="g">Graphics object, intended to be provided from the MainGUI</param>
        public override void Draw(Graphics g)
        {
            Pen p = new Pen(lineColor, lineWeight);
            SolidBrush b = new SolidBrush(fillColor);
            g.FillRectangle(b, x, y, width, length);
            g.DrawRectangle(p, x, y, width, length);
        }

        /// <summary>
        /// Uses the check variables xSet, xSet, lengthSet and widthSet to ascertain whether the required variables have been set.
        /// </summary>
        /// <returns></returns>
        public override bool HasRequiredVariables()
        {
            return lengthSet && widthSet && xSet && ySet;
        }

        /// <summary>
        /// Takes variables passed to the method from within the variables dictionary and assigns them to the relevent
        /// fields ready for execution when completed.
        /// x, y, length and width are the required fields.
        /// </summary>
        /// <param name="variables">A dictionary object to hold string values which can be parsed where required.</param>
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

        /// <summary>
        /// This overrides the base implemention of ToString() in this case this is now the Shape class.
        /// </summary>
        /// <returns>Example output: 'StringRef x=1, y=2 : length=3, width=3, perimeter=4, area=5'</returns>
        public override string ToString()
        {
            return base.ToString() + "length=" + this.length + ", width=" + this.width + ", perimeter=" + CalculatePerimeter() + ", area=" + CalculateArea();
        }
        #endregion
    }
}
