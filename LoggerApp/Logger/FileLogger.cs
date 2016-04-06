using System;
using System.Configuration;
using System.IO;

namespace LoggerApp.Logger
{
    public class FileLogger: ILog
    {
        public void Log(string message, LogLevel level)
        {
            var logContent = string.Empty;

            var fileName = ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" +
                               DateTime.Now.ToShortDateString() + ".txt";

            if (!File.Exists(fileName))
            {
                logContent = File.ReadAllText(fileName);
            }

            logContent = logContent + DateTime.Now.ToShortDateString() + message;
            
            File.WriteAllText(fileName, logContent);
        }
    }
}
