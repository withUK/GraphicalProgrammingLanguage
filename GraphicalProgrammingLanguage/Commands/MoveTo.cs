using GraphicalProgrammingLanguage.Enums;
using System.Collections.Generic;

namespace GraphicalProgrammingLanguage.Commands
{
    /// <summary>
    /// The move to command is implemented to move the position from the current point on the 
    /// MainGUI to x y coordinates that are passed via the Set method or on construction.
    /// 
    /// Syntax example : 
    /// Inline example
    ///     moveto(x=20,y=20)
    /// Seperate example
    ///     moveto
    ///     x=5
    ///     y=5
    /// </summary>
    public class MoveTo : Command
    {
        #region Properties
        protected int x { get; set; }
        private bool xSet { get; set; }
        protected int y { get; set; }
        private bool ySet { get; set; }
        #endregion

        #region Constructors
        public MoveTo(MainGUI main) : base(main)
        {
            name = CommandTypes.moveto.ToString();
        }

        public MoveTo(MainGUI main, Dictionary<string, string> variables) : base(main, variables)
        {
            name = CommandTypes.moveto.ToString();
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

        public override void Execute()
        {
            if (IsValid(variables))
            {
                Log(main);
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
        public override bool IsValid(Dictionary<string, string> variables)
        {
            return hasRequiredParameters();
        }
        #endregion
    }
}
