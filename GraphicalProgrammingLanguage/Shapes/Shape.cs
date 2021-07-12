using GraphicalProgrammingLanguage.Interfaces;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Shapes
{
    /// <summary>
    /// The base class to all shapes that are specified within the application. This class implements 
    /// the IShape interface of which only Set is written, CalculateArea, CalculatePerimeter, Draw and 
    /// hasRequiredVariables will left to the children of the base class.
    /// </summary>
    public abstract class Shape : IShape
    {
        #region Properties
        protected int x { get; set; }
        protected bool xSet { get; set; }
        protected int y { get; set; }
        protected bool ySet { get; set; }

        protected float lineWeight { get; set; }
        protected Color lineColor { get; set; }
        protected Color fillColor { get; set; }
        #endregion

        #region Constructors
        public Shape()
        {

        }

        public Shape(MainGUI main)
        {
            this.lineWeight = main.pen.Width;
            this.lineColor = main.pen.Color;
            this.fillColor = (main.brush as SolidBrush).Color;
        }

        public Shape(int x, int y, Color lineColor, Color fillColor, float lineWeight)
        {
            this.x = x;
            this.y = y;
            this.lineWeight = lineWeight;
            this.lineColor = lineColor;
            this.fillColor = fillColor;
        }
        #endregion

        #region Methods
        /// <summary>
        /// The 'set' method uses the params in position [0] as x, [1] as y and [2] as the line weight. 
        /// This virtual method can be overwritten by children of this class that can be more specfic to the shape.
        /// </summary>
        /// <param name="variables">A dictionary object to hold string values which can be parsed where required.</param>
        public virtual void Set(Dictionary<string, string> variables)
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
            if (variables.ContainsKey("lineweight"))
            {
                lineWeight = float.Parse(variables.GetValueOrDefault("lineWeight"));
            }
            if (variables.ContainsKey("linecolor"))
            {
                lineColor = Color.FromName(variables.GetValueOrDefault("lineColor"));
            }
            if (variables.ContainsKey("fillColor"))
            {
                fillColor = Color.FromName(variables.GetValueOrDefault("fillColor"));
            }
        }

        // Abstracts
        /// <summary>
        /// These methods have been brought in by the interface, as the class is abstract these methods are not reuqired 
        /// at this level and will be implemented by children of the Shape base class.
        /// </summary>
        /// <returns></returns>
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
        public abstract void Draw(Graphics g);
        public abstract bool HasRequiredVariables();
        #endregion

        #region Overrides
        /// <summary>
        /// This overrides the base implemention of ToString() but combines with the x & y values.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + " : x=" + this.x + ", y=" + this.y + " : ";
        }
        #endregion
    }
}
