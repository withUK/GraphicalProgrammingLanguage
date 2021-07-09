using GraphicalProgrammingLanguage.Enums;
using GraphicalProgrammingLanguage.Commands;
using System;

namespace GraphicalProgrammingLanguage.Factories
{
    /// <summary>
    /// Making use of the factory design pattern this class is created to generate commands freely available
    /// within the command parser.
    /// Enums utilised for consistent evaluations within the switch statement.
    /// </summary>
    public class CommandFactory
    {
        public Command GetCommand(MainGUI main, String commandType)
        {
            try
            {
                var type = Enum.Parse(typeof(CommandTypes), commandType);

                switch(type)
                {
                    case CommandTypes.clear:
                        return new Clear(main);
                    case CommandTypes.drawshape:
                        return new DrawShape(main);
                    case CommandTypes.drawto:
                        return new DrawTo(main);
                    case CommandTypes.moveto:
                        return new MoveTo(main);
                    case CommandTypes.reset:
                        return new Reset(main);
                    case CommandTypes.setfill:
                        return new SetFill(main);
                    case CommandTypes.setpen:
                        return new SetPen(main);
                    default:
                        ArgumentException argEx = new ArgumentException("CommandFactory error: " + commandType + " does not exist");
                        throw argEx;
                }
            }
            catch (ArgumentException argEx)
            {
                throw argEx;
            }
        }
    }
}
