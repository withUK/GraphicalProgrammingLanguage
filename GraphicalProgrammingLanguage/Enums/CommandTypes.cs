using System.ComponentModel.DataAnnotations;

namespace GraphicalProgrammingLanguage.Enums
{
    internal enum CommandTypes
    {
        [Display(Name = "Clear")]
        clear,
        [Display(Name = "Draw shape")]
        drawShape,
        [Display(Name = "Draw to")]
        drawTo,
        [Display(Name = "Move to")]
        moveTo,
        [Display(Name = "Reset")]
        reset,
        [Display(Name = "Set fill")]
        setFill,
        [Display(Name = "Set pen")]
        setPen
    }
}
