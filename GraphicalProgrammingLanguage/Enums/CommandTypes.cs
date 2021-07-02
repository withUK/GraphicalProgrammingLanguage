using System.ComponentModel.DataAnnotations;

namespace GraphicalProgrammingLanguage.Enums
{
    internal enum CommandTypes
    {
        [Display(Name = "Clear")]
        clear,
        [Display(Name = "Draw shape")]
        drawshape,
        [Display(Name = "Draw to")]
        drawto,
        [Display(Name = "Move to")]
        moveto,
        [Display(Name = "Reset")]
        reset,
        [Display(Name = "Set fill")]
        setfill,
        [Display(Name = "Set pen")]
        setpen
    }
}
