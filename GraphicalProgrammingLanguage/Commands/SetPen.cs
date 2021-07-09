using GraphicalProgrammingLanguage.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GraphicalProgrammingLanguage.Commands
{
    /// <summary>
    /// A dymanic command, set pen is designed to set the color or weight of the pen by passing the name 
    /// of the parameters. This means weight and color can be set separatly or as part of one call.
    /// 
    /// Syntax example : 
    ///     setpen(weight=3)
    ///     setpen(color=red)
    ///     setpen(weight=3,color=red)
    /// </summary>
    public class SetPen : Command
    {
        #region Properties
        protected Pen pen;

        private bool colorSet { get; set; }
        private bool weightSet { get; set; }
        #endregion

        #region Constructors
        public SetPen(MainGUI main) : base(main)
        {
            name = CommandTypes.setpen.ToString();
            pen = main.pen;
        }
        #endregion

        #region Overrides
        public void set(Dictionary<string, string> variables)
        {
            this.variables = variables;
            if (variables != null)
            {
                if (variables.ContainsKey("color"))
                {
                    colorSet = true;
                }
                if (variables.ContainsKey("weight"))
                {
                    weightSet = true;
                }
            }
        }

        public override void Execute()
        {
            if (IsValid(variables))
            {
                Log(main);
                if (variables.ContainsKey("color"))
                {
                    pen.Color = Color.FromName(variables.GetValueOrDefault("color"));
                }
                if (variables.ContainsKey("weight"))
                {
                    pen.Width = float.Parse(variables.GetValueOrDefault("weight"));
                }
            }
        }


        /// <summary>
        /// With the command being dynamic in nature has requirements uses the OR logic between the 
        /// bool variables weightset and colorset.
        /// </summary>
        /// <returns></returns>
        public override bool hasRequiredParameters()
        {
            return weightSet || colorSet;
        }

        /// <summary>
        /// The validity of the command come from the correct variables and so uses hasRequiredParameters.
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
