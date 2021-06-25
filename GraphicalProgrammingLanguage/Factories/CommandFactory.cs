using GraphicalProgrammingLanguage.Enums;
using GraphicalProgrammingLanguage.Commands;
using System;

namespace GraphicalProgrammingLanguage.Factories
{
    class CommandFactory
    {
        public Command getCommand(String commandType)
        {
            var type = Enum.Parse(typeof(CommandTypes), commandType);

            switch(type)
            {
                case CommandTypes.clear:
                    return new Clear();
                case CommandTypes.drawShape:
                    return new DrawShape();
                case CommandTypes.drawTo:
                    return new DrawTo();
                case CommandTypes.moveTo:
                    return new MoveTo();
                case CommandTypes.reset:
                    return new Reset();
                case CommandTypes.setFill:
                    return new SetFill();
                case CommandTypes.setPen:
                    return new SetPen();
                default:
                    ArgumentException argEx = new ArgumentException("CommandFactory error: " + commandType + " does not exist");
                    throw argEx;
            }
        }
    }
}
