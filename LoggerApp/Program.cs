using LoggerApp.Logger;

namespace LoggerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var loggers = new ILog[]
            {
                new FileLogger(), new ConsoleLogger(), new SqlLogger()
            };

            var loggerHandler = new MyJobLogger(loggers, 
                canLogInfo: true, canLogWarning: false, canLogError: false);
            
            loggerHandler.Log("", LogLevel.Info);

        }
    }
}
