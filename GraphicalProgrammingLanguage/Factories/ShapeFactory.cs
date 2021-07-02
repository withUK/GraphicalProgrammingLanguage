using GraphicalProgrammingLanguage.Enums;
using GraphicalProgrammingLanguage.Shapes;
using System;

namespace GraphicalProgrammingLanguage.Factories
{
    class ShapeFactory
    {
        public Shape getShape(MainGUI main, String shapeType)
        {
            var type = Enum.Parse(typeof(ShapeTypes), shapeType.ToLower());

            switch (type)
            {
                case ShapeTypes.circle:
                    return new Circle(main);
                case ShapeTypes.rectangle:
                    return new Rectangle(main);
                case ShapeTypes.square:
                    return new Square(main);
                case ShapeTypes.triangle:
                    return new Triangle(main);
                default:
                    ArgumentException argEx = new ArgumentException("ShapeFactory error: " + shapeType + " does not exist");
                    throw argEx;
            }
        }
    }
}
