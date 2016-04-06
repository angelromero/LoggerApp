using System;
using System.Collections.Generic;

namespace LoggerApp.Logger
{
    public class ConsoleLogger: ILog
    {
        private readonly Dictionary<LogLevel, ConsoleColor> _levelColorConsole = new Dictionary<LogLevel, ConsoleColor>
        {
            { LogLevel.Error, ConsoleColor.Red },
            { LogLevel.Warning, ConsoleColor.Yellow },
            { LogLevel.Info, ConsoleColor.White },
        }; 
        
        public void Log(string message, LogLevel level)
        {
            Console.ForegroundColor = _levelColorConsole[level];
            Console.WriteLine(DateTime.Now.ToShortDateString() + message);
        }
    }
}
