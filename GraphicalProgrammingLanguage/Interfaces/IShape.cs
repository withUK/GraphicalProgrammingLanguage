using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Interfaces
{
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
