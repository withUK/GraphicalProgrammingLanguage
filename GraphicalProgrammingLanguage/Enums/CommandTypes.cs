using System.ComponentModel.DataAnnotations;

namespace GraphicalProgrammingLanguage.Enums
{
    /// <summary>
    /// Enum values of defined commands, these are used for consistancy throughout the application.
    /// </summary>
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
