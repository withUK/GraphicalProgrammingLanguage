using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GraphicalProgrammingLanguage.Enums
{
    internal enum ShapeTypes
    {
        [Display(Name = "Circle")]
        circle,
        [Display(Name = "Rectangle")]
        rectangle,
        [Display(Name = "Square")]
        square
    }
}
