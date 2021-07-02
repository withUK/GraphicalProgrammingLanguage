using System.ComponentModel.DataAnnotations;

namespace GraphicalProgrammingLanguage.Enums
{
    internal enum ShapeTypes
    {
        [Display(Name = "Circle")]
        circle,
        [Display(Name = "Rectangle")]
        rectangle,
        [Display(Name = "Square")]
        square,
        [Display(Name = "Triangle")]
        triangle,
        [Display(Name = "Polygon")]
        polygon
    }
}
