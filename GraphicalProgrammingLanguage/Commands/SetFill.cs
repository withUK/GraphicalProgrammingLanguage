using GraphicalProgrammingLanguage.Enums;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Commands
{
    /// <summary>
    /// Set fill makes use of the brush object to set the color of any shapes drawn on the MainGUI's
    /// graphic. In this application it is the SolidBrush type that is used and does not offer configuration
    /// to any other type.
    /// By including a color value within the parentheses that color is used, using empty paretheses sets the 
    /// fill to transparent effectively turning the fill off.
    /// 
    /// Syntax example : 
    ///     setfill(color=red)
    ///     setfill()
    /// </summary>
    public class SetFill : Command
    {
        #region Properties
        protected Brush brush;
        #endregion

        #region Constructors
        public SetFill(MainGUI main) : base(main)
        {
            name = CommandTypes.setfill.ToString();
            brush = main.brush;
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Takes variables passed to the method from within the variables dictionary and assigns them to the relevent
        /// fields ready for execution when completed.
        /// </summary>
        /// <param name="variables">A dictionary object to hold string values which can be parsed where required.</param>
        public void set(Dictionary<string, string> variables)
        {
            this.variables = variables;
            if (variables != null)
            {
                if (variables.ContainsKey("color"))
                {
                    brush = new SolidBrush(Color.FromName(variables.GetValueOrDefault("color")));
                }
                else
                {
                    brush = new SolidBrush(Color.Transparent);
                }
            }
        }

        /// <summary>
        /// Begins the command if valid and sets the brush object within the MainGUI to the one built wihin this class.
        /// If not valid then message added to the log.
        /// </summary>
        public override void Execute()
        {
            if (IsValid(variables))
            {
                Log(main);
                main.brush = brush;
            }
            else
            {
                Logger.Log($"Unable to execute {name}");
            }
        }

        /// <summary>
        /// Checks the class to ensure it has what is required to successfully execute the action.
        /// </summary>
        /// <returns>Returns true as no variables required for this action to execute.</returns>
        public override bool hasRequiredParameters()
        {
            return true;
        }

        /// <summary>
        /// Makes use of the hasRequiredParameters method as there is no further logic required to verify the action.
        /// </summary>
        /// <param name="variables">A dictionary object to hold string values which can be parsed where required.</param>
        /// <returns>Returns true as no variables required for this action to execute.</returns>
        public override bool IsValid(Dictionary<string, string> variables)
        {
            return hasRequiredParameters();
        }
        #endregion
    }
}
