using System;
using System.IO;

namespace GraphicalProgrammingLanguage
{
    public class Logger
    {
        public static string LogLaunch()
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                string entry = $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} : Application started";
                w.WriteLine(entry);
                return entry;
            }
        }

        public static string LogClose()
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                string entry = $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} : Application ended";
                w.WriteLine(entry);
                return entry;
            }
        }

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
