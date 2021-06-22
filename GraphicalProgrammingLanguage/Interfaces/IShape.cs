using System.Drawing;

namespace GraphicalProgrammingLanguage.Interfaces
{
    interface IShape
    {
        // Methods
        void set(Color lineColor, Color fillColor, params int[] list);
        double calculateArea();
        double calculatePerimeter();
        void draw(Graphics g);
    }
}
