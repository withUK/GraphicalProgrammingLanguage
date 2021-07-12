using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Shapes
{
    public class Circle : Shape
    {
        #region Properties
        public int radius { get; set; }
        private bool radiusSet { get; set; }
        #endregion

        #region Constructors
        public Circle() : base() { }

        public Circle(MainGUI main) : base(main) { }
        
        /// <summary>
        /// This constructor is passed all the variables required to action the draw method following instantiated.
        /// </summary>
        /// <param name="x">Horizontal coordinate of the pen.</param>
        /// <param name="y">Verticle coordinate of the pen.</param>
        /// <param name="radius">The expected radius of the drawn object.</param>
        /// <param name="lineColor">The string value of a color for the line.</param>
        /// <param name="fillColor">The string value of a color for the fill.</param>
        /// <param name="lineWeight">The width of the line.</param>
        public Circle(int x, int y, int radius, Color lineColor, Color fillColor, float lineWeight) : base(x, y, lineColor, fillColor, lineWeight)
        {
            Dictionary<string, string> variables = new Dictionary<string, string>();
            variables.Add("x", x.ToString());
            variables.Add("y", y.ToString());
            variables.Add("radius", radius.ToString());
            variables.Add("linecolor", lineColor.ToString());
            variables.Add("fillcolor", fillColor.ToString());
            variables.Add("lineweight", lineWeight.ToString());
            Set(variables);
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Takes variables passed to the method from within the variables dictionary and assigns them to the relevent
        /// fields ready for execution when completed.
        /// x, y and radius are the required fields.
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
        /// Calculates the area of the created shape using the PI value from the C# Math library.
        /// </summary>
        /// <returns>The calulated value of the area in an unrestricted decimal format.</returns>
        public override double CalculateArea()
        {
            return Math.PI * (radius ^ 2);
        }

        /// <summary>
        /// Calculates the perimeter of the created shape using the PI value from the C# Math library.
        /// </summary>
        /// <returns>The calulated value of the perimeter in an unrestricted decimal format.</returns>
        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }

        /// <summary>
        /// The action that adds the specified shape the MainGUI graphic object.
        /// </summary>
        /// <param name="g">Graphics object, intended to be provided from the MainGUI</param>
        public override void Draw(Graphics g)
        {
            Pen p = new Pen(lineColor, lineWeight);
            SolidBrush b = new SolidBrush(fillColor);
            g.FillEllipse(b, x, y, radius * 2, radius * 2);
            g.DrawEllipse(p, x, y, radius * 2, radius * 2);
        }

        /// <summary>
        /// Uses the check variables xSet, xSet and radiusSet to ascertain whether the required variables have been set.
        /// </summary>
        /// <returns></returns>
        public override bool HasRequiredVariables()
        {
            return radiusSet && xSet && ySet;
        }

        /// <summary>
        /// This overrides the base implemention of ToString() in this case this is now the Shape class.
        /// </summary>
        /// <returns>Example output: 'StringRef x=1, y=2 : radius=3, perimeter=4, area=5'</returns>
        public override string ToString()
        {
            return base.ToString() + "radius=" + this.radius + ", perimeter=" + CalculatePerimeter() + ", area=" + CalculateArea();
        }
        #endregion
    }
}
