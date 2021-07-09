using System.ComponentModel.DataAnnotations;

namespace GraphicalProgrammingLanguage.Enums
{
    /// <summary>
    /// Enum values of defined shapes, these are used for consistancy throughout the application.
    /// </summary>
    public enum ShapeTypes
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
