using GraphicalProgrammingLanguage.Data;
using GraphicalProgrammingLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicalProgrammingLanguage
{
    public class UsageCounter
    {
        public static void AddToCommandCount(string commandName)
        {
            using (CommandsContext db = new CommandsContext())
            {
                var command = db.CommandUsage.Where(c => commandName.Equals(c.CommandName)).FirstOrDefault();
                command.UsageCount++;
                db.CommandUsage.Update(command);
                db.SaveChanges();
            }
        }

        public static List<string> GetUsageCountOutput()
        {
            List<CommandUsageCount> usage = new List<CommandUsageCount>();
            List<string> output = new List<string>();

            using (CommandsContext db = new CommandsContext())
            {
                foreach (var item in db.CommandUsage)
                {
                    usage.Add(item);
                }
            }

            usage = usage.OrderByDescending(c => c.UsageCount).ToList();

            foreach (var item in usage)
            {
                output.Add(String.Concat(" ", item.CommandName, "\t: ", item.SyntaxExample));
            }

            return output;
        }
    }
}
