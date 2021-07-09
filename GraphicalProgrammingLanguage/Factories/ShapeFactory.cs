using GraphicalProgrammingLanguage.Enums;
using GraphicalProgrammingLanguage.Shapes;
using System;

namespace GraphicalProgrammingLanguage.Factories
{
    /// <summary>
    /// Making use of the factory design pattern this class is created to generate shape objects freely 
    /// within the draw shape class.
    /// Enums utilised for consistent evaluations within the switch statement.
    /// </summary>
    public class ShapeFactory
    {
        public Shape GetShape(MainGUI main, String shapeType)
        {
            try
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
            catch (ArgumentException argEx)
            {
                throw argEx;
            }
        }
    }
}
