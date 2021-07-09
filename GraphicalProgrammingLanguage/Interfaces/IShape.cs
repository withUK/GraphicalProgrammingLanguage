using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Interfaces
{
    /// <summary>
    /// The shape interface holds methods used for common actions relating to a generic shape.
    /// CalculateArea and CalculatePerimenter are intended to be used within the override for toString() method.
    /// </summary>
    interface IShape
    {
        // Methods
        void Set(Dictionary<string, string> variables);
        double CalculateArea();
        double CalculatePerimeter();
        void Draw(Graphics g);
        bool HasRequiredVariables();
    }
}
