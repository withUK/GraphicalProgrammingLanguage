using GraphicalProgrammingLanguage.Interfaces;
using System.Collections.Generic;

namespace GraphicalProgrammingLanguage.Commands
{
    /// <summary>
    /// The base class to all commands that are specified within the application. This class implements 
    /// the ICommand interface of which only Set and Log are written, Execute, HasRequiredParameters and 
    /// IsValid will left to the children of the base class.
    /// </summary>
    public abstract class Command : ICommand
    {
        #region Properties
        protected MainGUI main { get; set; }
        public string name { get; set; }
        protected Dictionary<string,string> variables { get; set; }
        #endregion

        #region Constructors
        public Command(MainGUI main)
        {
            this.main = main;
        }

        public Command(MainGUI main, Dictionary<string, string> variables)
        {
            this.main = main;
            this.variables = variables;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 'Set' within this base class takes the variables provided and assigns them to the Dictionary 
        /// that is defined within this class.
        /// By using a Dictiaonary and setting it at the base class it reduces the need to set multiple 
        /// times and can concentrate on the logic within the child.
        /// </summary>
        /// <param name="variables">A dictionary object to hold string values which can be parsed where required.</param>
        public void Set(Dictionary<string, string> variables)
        {
            this.variables = variables;
        }

        /// <summary>
        /// The base implemetation of the Log() method is created to record when a command is called, child
        /// implementations can hold more specific information if required.
        /// </summary>
        /// <param name="main"></param>
        public void Log(MainGUI main)
        {
            main.txtLog.AppendText(Logger.Log($"Command {name} called."));
        }

        // Abstracts
        /// <summary>
        /// These methods have been brought in by the interface, as the class is abstract these methods are 
        /// not reuqired at this level and will be implemented by children of the Command base class.
        /// </summary>
        /// <returns></returns>
        public abstract void Execute();
        public abstract bool hasRequiredParameters();
        public abstract bool IsValid(Dictionary<string, string> variables);
        #endregion
    }
}
