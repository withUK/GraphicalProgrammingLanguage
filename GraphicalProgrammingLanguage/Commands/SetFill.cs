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

        #region Methods
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
        
        public override void execute()
        {
            if (isValid(variables))
            {
                log(main);
                main.brush = brush;
            }
        }

        public override bool hasRequiredParameters()
        {
            return true;
        }

        public override bool isValid(Dictionary<string, string> variables)
        {
            return hasRequiredParameters();
        }
        #endregion
    }
}
