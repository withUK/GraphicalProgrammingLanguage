using GraphicalProgrammingLanguage.Enums;
using GraphicalProgrammingLanguage.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Factories
{
    class CommandFactory
    {
        public Command getCommand(MainGUI main, String commandType)
        {
            var type = Enum.Parse(typeof(CommandTypes), commandType);

            switch(type)
            {
                case CommandTypes.clear:
                    return new Clear(main);
                case CommandTypes.drawShape:
                    return new DrawShape(main);
                case CommandTypes.drawTo:
                    return new DrawTo(main);
                case CommandTypes.moveTo:
                    return new MoveTo(main);
                case CommandTypes.reset:
                    return new Reset(main);
                case CommandTypes.setFill:
                    return new SetFill(main);
                case CommandTypes.setPen:
                    return new SetPen(main);
                default:
                    ArgumentException argEx = new ArgumentException("CommandFactory error: " + commandType + " does not exist");
                    throw argEx;
            }
        }
    }
}
