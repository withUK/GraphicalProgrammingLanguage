﻿using System;
using System.IO;

namespace GraphicalProgrammingLanguage
{
    class Logger
    {
        public static string Log(string message)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                string entry = $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} : {message}";
                w.WriteLine(entry);
                return entry;
            }
        }
    }
}
