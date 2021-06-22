using System;
using System.IO;

namespace GraphicalProgrammingLanguage
{
    class Logger
    {
        public static string Log(string message, TextWriter w)
        {
            string entry = $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} : {message}";
            w.WriteLine(entry);
            return entry;
        }
    }
}
