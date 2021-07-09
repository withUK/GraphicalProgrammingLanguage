using GraphicalProgrammingLanguage.Enums;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Commands
{
    /// <summary>
    /// The clear command is designed to take the graphic from the pnlOutput within the MainGui object
    /// and clears anything that had been added to it.
    /// 
    /// Syntax example : 
    ///     clear
    /// </summary>
    public class Clear : Command
    {
        #region Constructors
        public Clear(MainGUI main) : base(main)
        {
            name = CommandTypes.clear.ToString();
        }
        #endregion

        #region Overrides
        public override void Execute()
        {
            if (IsValid(new Dictionary<string, string>()))
            {
                Log(main);
                main.dc.Clear(Color.Gainsboro);
            }
        }

        /// <summary>
        /// HasRequiredParameters returns true without any logic due to the fact the Clear command does 
        /// not require any parameters.
        /// The method is implemented this way to follow the established pattern within the CommandParser 
        /// class, it has the additional benefit of being able to add further logic in future if the 
        /// application changes in future iterations.
        /// </summary>
        /// <returns></returns>
        public override bool hasRequiredParameters()
        {
            return true;
        }

        /// <summary>
        /// IsValid returns true without any logic due to the fact the Clear command does 
        /// not require any parameters.
        /// The method is implemented this way to follow the established pattern within the CommandParser 
        /// class, it has the additional benefit of being able to add further logic in future if the 
        /// application changes in future iterations.
        /// </summary>
        /// <param name="variables"></param>
        /// <returns></returns>
        public override bool IsValid(Dictionary<string, string> variables)
        {
            return true;
        }
        #endregion
    }
}
