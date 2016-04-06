using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace LoggerApp
{
    public class JobLogger
    {
        private static bool _logToFile;
        private static bool _logToConsole;
        private static bool _logToDatabase;

        private static bool _logInfo;
        private static bool _logWarning;
        private static bool _logError;
        
        public JobLogger(bool logToFile, bool logToConsole, bool logToDatabase, 
            bool logInfo, bool logWarning, bool logError)

        {
            _logError = logError;
            _logInfo = logInfo;
            _logWarning = logWarning;
            _logToDatabase = logToDatabase;
            _logToFile = logToFile;
            _logToConsole = logToConsole;
        }

        public static void LogMessage(string message, bool isInfo, bool isWarning, bool isError)
        {
            //VALIDATION -------------------------------------------
            //message.Trim();

            //if (message == null || message.Length == 0)
            //{
            //    return;
            //}

            //if (!_logToConsole && !_logToFile && !_logToDatabase)
            //{
            //    throw new Exception("Invalid configuration");
            //}

            //if ((!_logError && !_logInfo && !_logWarning) || (!isInfo && !isWarning && !isError))
            //{
            //    throw new Exception("Error or Warning or Message must be specified");
            //}
            //-------------------------------------------


            //SQL LOGGER ********************************

            //var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            //connection.Open();

            //var t = 0;

            //if (isInfo && _logInfo)
            //{
            //    t = 1;
            //}

            //if (error && _logError)
            //{
            //    t = 2;
            //}

            //if (warning && _logWarning)
            //{
            //    t = 3;
            //}

            //var command = new SqlCommand("Insert into Log Values('" + message + "', " + t + ")");
            //command.ExecuteNonQuery();

            //FILE LOGGER ********************************
            //var l = string.Empty;

            //if (!File.Exists(ConfigurationManager.AppSettings["Log FileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt"))
            //{
            //    l = File.ReadAllText(ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt");
            //}

            //if (error && _logError)
            //{
            //    l = l + DateTime.Now.ToShortDateString() + message;
            //}

            //if (warning && _logWarning)
            //{
            //    l = l + DateTime.Now.ToShortDateString() + message;
            //}

            //if (ismessage && _logInfo)
            //{
            //    l = l + DateTime.Now.ToShortDateString() + message;
            //}
            

            //File.WriteAllText(
            //    ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() +
            //    ".txt", l);
            //***********************************************

            //CONSOLE LOGGER ********************************
            //if (error && _logError)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //}

            //if (warning && _logWarning)
            //{
            //    Console.ForegroundColor = ConsoleColor.Yellow;
            //}

            //if (ismessage && _logInfo)
            //{
            //    Console.ForegroundColor = ConsoleColor.White;
            //}

            //Console.WriteLine(DateTime.Now.ToShortDateString() + message);
        }
    }
}