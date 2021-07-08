using GraphicalProgrammingLanguage.Data;
using GraphicalProgrammingLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicalProgrammingLanguage
{
    /// <summary>
    /// The UsageCounter class helper is a set of staic methods that read and write to the GPL_DATABASE held within the source
    /// files. Each method is wrapped in a context using statement to handle the resource efficiently by closing the connection 
    /// after the method has been exited.
    /// </summary>
    public class UsageCounter
    {
        /// <summary>
        /// Matching to the given commandName variable, this method increases the count of the record by one each time it is called.
        /// </summary>
        /// <param name="commandName"></param>
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

        /// <summary>
        /// Used within the MainGUI class GetUsageOutput() is called to provide the data from the DB in a formatted manner as well as ordered 
        /// by the most recent usage count.
        /// The outputted string concatinates the CommandName followed by a tab space and then the SyntaxExample, delimited by a colon.
        /// </summary>
        /// <returns></returns>
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
