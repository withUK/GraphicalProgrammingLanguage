using GraphicalProgrammingLanguage.Enums;
using System.Collections.Generic;

namespace GraphicalProgrammingLanguage.Commands
{
    /// <summary>
    /// The draw to command is implemented to add a graphical line from the current point on the 
    /// MainGUI to x y coordinates that are passed via the Set method or on construction. This line
    /// uses the current value of the pen weight and color from the MainGUI. 
    /// 
    /// Syntax example : 
    /// Inline example
    ///     drawto(x=20,y=20)
    /// Seperate example
    ///     drawto
    ///     x=5
    ///     y=5
    /// </summary>
    public class DrawTo : Command
    {
        #region Properties
        protected int x { get; set; }
        private bool xSet { get; set; }
        protected int y { get; set; }
        private bool ySet { get; set; }
        #endregion

        #region Constructors
        public DrawTo(MainGUI main) : base(main)
        {
            name = CommandTypes.drawto.ToString();
        }

        public DrawTo(MainGUI main, Dictionary<string,string>variables) : base(main, variables)
        {
            name = CommandTypes.drawto.ToString();
        }
        #endregion

        #region Overrides
        public void set(Dictionary<string, string> variables)
        {
            this.variables = variables;
            if (variables != null)
            {
                if (variables.ContainsKey("x"))
                {
                    x = int.Parse(variables.GetValueOrDefault("x"));
                    xSet = true;
                }
                if (variables.ContainsKey("y"))
                {
                    y = int.Parse(variables.GetValueOrDefault("y"));
                    ySet = true;
                }
            }
        }

        public override void execute()
        {
            if (isValid(variables))
            {
                log(main);
                main.dc.DrawLine(main.pen, main.x, main.y, x, y);
                main.x = x;
                main.y = y;
            }
        }

        /// <summary>
        /// This implementation of the HasRequiredParameters checks the boolean values set when the 
        /// coresponding x or y value are set via the parameters.
        /// </summary>
        /// <returns></returns>
        public override bool hasRequiredParameters()
        {
            if (xSet && ySet)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// With the lack of additional logic requirements the IsValid method makes use of the hasRequiredParameters'
        /// method.
        /// </summary>
        /// <param name="variables"></param>
        /// <returns></returns>
        public override bool isValid(Dictionary<string, string> variables)
        {
            return hasRequiredParameters();
        }
        #endregion
    }
}
