using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Shapes
{
    public class Triangle : Shape
    {
        #region Properties
        Point p1 { get; set; }
        private bool p1Set { get; set; }
        Point p2 { get; set; }
        private bool p2Set { get; set; }
        Point p3 { get; set; }
        private bool p3Set { get; set; }
        Point[] points { get; set; }
        #endregion

        #region Constructors
        public Triangle() : base()
        {

        }

        public Triangle(MainGUI main) : base(main)
        {

        }

        /// <summary>
        /// This constructor is passed the variables required to action the draw method following instantiation.
        /// </summary>
        /// <param name="x">Horizontal coordinate of the pen.</param>
        /// <param name="y">Verticle coordinate of the pen.</param>
        /// <param name="lineColor">The string value of a color for the line.</param>
        /// <param name="fillColor">The string value of a color for the fill.</param>
        /// <param name="lineWeight">The width of the line.</param>
        /// <param name="x2">Horizontal coordinate of the pen for the second point.</param>
        /// <param name="y2">Verticle coordinate of the pen for the second point.</param>
        /// <param name="x3">Horizontal coordinate of the pen for the third point.</param>
        /// <param name="y3">Verticle coordinate of the pen for the third point.</param>
        public Triangle(int x, int y, Color lineColor, Color fillColor, float lineWeight, int x2, int y2, int x3, int y3) : base(x, y, lineColor, fillColor, lineWeight)
        {
            Dictionary<string, string> variables = new Dictionary<string, string>();
            variables.Add("p1", string.Concat(x.ToString(), ",", y.ToString()));
            variables.Add("p2", string.Concat(x2.ToString(), ",", y2.ToString()));
            variables.Add("p3", string.Concat(x3.ToString(), ",", y3.ToString()));
            variables.Add("linecolor", lineColor.ToString());
            variables.Add("fillcolor", fillColor.ToString());
            variables.Add("lineweight", lineWeight.ToString());
            Set(variables);
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Calculates the area of the created shape using the given coordinate points properties.
        /// </summary>
        /// <returns>The calulated value of the area in an unrestricted decimal format.</returns>
        public override double CalculateArea()
        {
            return 0.5 * (p1.X * (p2.Y - p3.Y) + p2.X * (p3.Y - p1.Y) + p3.X * (p1.Y - p2.Y));
        }

        /// <summary>
        /// Calculates the perimeter of the created shape using the given length and width properties.
        /// </summary>
        /// <returns>The calulated value of the perimeter in an unrestricted decimal format.</returns>
        public override double CalculatePerimeter()
        {
            var l1 = Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
            var l2 = Math.Sqrt((p2.X - p3.X) * (p2.X - p3.X) + (p2.Y - p3.Y) * (p2.Y - p3.Y));
            var l3 = Math.Sqrt((p3.X - p1.X) * (p3.X - p1.X) + (p3.Y - p1.Y) * (p3.Y - p1.Y));

            return l1 + l2 + l3;
        }

        /// <summary>
        /// The action that adds the specified shape the MainGUI graphic object.
        /// </summary>
        /// <param name="g">Graphics object, intended to be provided from the MainGUI</param>
        public override void Draw(Graphics g)
        {
            Pen p = new Pen(lineColor, lineWeight);
            SolidBrush b = new SolidBrush(fillColor);
            
            g.FillPolygon(b, points);
            g.DrawPolygon(p, points);
        }

        /// <summary>
        /// Uses the check variables p1Set, p2Set and p3Set to ascertain whether the required variables have been set.
        /// </summary>
        /// <returns></returns>
        public override bool HasRequiredVariables()
        {
            return p1Set && p2Set && p3Set;
        }

        /// <summary>
        /// Takes variables passed to the method from within the variables dictionary and assigns them to the relevent
        /// fields ready for execution when completed.
        /// p1, p2 and p3 are the required fields.
        /// </summary>
        /// <param name="variables">A dictionary object to hold string values which can be parsed where required.</param>
        public override void Set(Dictionary<string, string> variables)
        {
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

            if (variables.ContainsKey("p1"))
            {
                string pString = variables.GetValueOrDefault("p1");
                if (pString.Contains(","))
                {
                    string[] pSplit = pString.Split(",");
                    p1 = new Point { X = int.Parse(pSplit[0]), Y = int.Parse(pSplit[1]) };
                    p1Set = true;
                }
            }
            if (variables.ContainsKey("p2"))
            {
                string pString = variables.GetValueOrDefault("p2");
                if (pString.Contains(","))
                {
                    string[] pSplit = pString.Split(",");
                    p2 = new Point { X = int.Parse(pSplit[0]), Y = int.Parse(pSplit[1]) };
                    p2Set = true;
                }
            }
            if (variables.ContainsKey("p3"))
            {
                string pString = variables.GetValueOrDefault("p3");
                if (pString.Contains(","))
                {
                    string[] pSplit = pString.Split(",");
                    p3 = new Point { X = int.Parse(pSplit[0]), Y = int.Parse(pSplit[1]) };
                    p3Set = true;
                }
            }

            if (p1Set && p2Set && p3Set)
            {
                points = new Point[] { p1, p2, p3 };
            }
        }

        public override string ToString()
        {
            return base.ToString() + "p1=" + p1.ToString() + ", p2=" + p2.ToString() + ", p3=" + p3.ToString() + ", perimeter=" + CalculatePerimeter() + ", area=" + CalculateArea();
        }
        #endregion
    }
}
