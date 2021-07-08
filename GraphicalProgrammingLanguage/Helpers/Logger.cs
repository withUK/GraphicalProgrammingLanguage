using System;
using System.IO;

namespace GraphicalProgrammingLanguage
{
    /// <summary>
    /// The Logger class helper is a set of staic methods that write to an exernal log.txt file held within the source
    /// files. The messages generally are designed to reflect the output of the command and also what was input.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// On the launch of the application this method is called to write the event in the log.txt file as well as write 
        /// to the txtLog visual control with the DateTime stamp preceeding it.
        /// </summary>
        /// <returns></returns>
        public static string LogLaunch()
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                string entry = $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} : Application started";
                w.WriteLine(entry);
                return entry;
            }
        }
        /// <summary>
        /// As with the LogLaunch the LogClose method is invoked when the application is closed. It still uses the same log.txt 
        /// file with the DateTime stamp preceeding it however this method does not write to the txtLog object.
        /// </summary>
        /// <returns></returns>
        public static void LogClose()
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                string entry = $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} : Application ended";
                w.WriteLine(entry);
            }
        }

        /// <summary>
        /// Log() writes any given string to the log.txt file and the txtLog UI control on a fresh line along with the DateTime 
        /// stamp preceeding it.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string Log(string message)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                string entry = $"\n{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} : {message}";
                w.WriteLine(entry);
                return entry;
            }
        }
    }
}
