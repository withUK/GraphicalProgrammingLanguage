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
        void set(Dictionary<string, string> variables);
        double calculateArea();
        double calculatePerimeter();
        void draw(Graphics g);
        bool hasRequiredVariables();
    }
}
