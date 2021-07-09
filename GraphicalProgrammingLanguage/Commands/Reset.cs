using GraphicalProgrammingLanguage.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GraphicalProgrammingLanguage.Commands
{
    /// <summary>
    /// The reset command is designed to take the graphic from the pnlOutput within the MainGui object
    /// and clears anything that had been added to it as well as moving the x & y value back to 0.
    /// 
    /// Syntax example : 
    ///     reset
    /// </summary>
    public class Reset : Command
    {
        #region Constructors
        public Reset(MainGUI main) : base(main)
        {
            name = CommandTypes.reset.ToString();
        }
        #endregion

        #region Overrides
        public override void Execute()
        {
            if (IsValid(new Dictionary<string, string>()))
            {
                Log(main);
                main.x = 0;
                main.y = 0;
                main.dc.Clear(Color.Gainsboro);
            }
        }

        /// <summary>
        /// HasRequiredParameters returns true without any logic due to the fact the Reset command does 
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
        /// IsValid returns true without any logic due to the fact the Reset command does 
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
