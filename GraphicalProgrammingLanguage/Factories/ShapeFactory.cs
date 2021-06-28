using GraphicalProgrammingLanguage.Enums;
using GraphicalProgrammingLanguage.Shapes;
using System;

namespace GraphicalProgrammingLanguage.Factories
{
    class ShapeFactory
    {
        public Shape getShape(String shapeType)
        {
            var type = Enum.Parse(typeof(ShapeTypes), shapeType.ToLower());

            switch (type)
            {
                case ShapeTypes.circle:
                    return new Circle();
                case ShapeTypes.rectangle:
                    return new Rectangle();
                case ShapeTypes.square:
                    return new Square();
                default:
                    ArgumentException argEx = new ArgumentException("ShapeFactory error: " + shapeType + " does not exist");
                    throw argEx;
            }
        }
    }
}
