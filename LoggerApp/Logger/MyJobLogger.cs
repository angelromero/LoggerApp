using System;
using System.Collections.Generic;
using System.Linq;

namespace LoggerApp.Logger
{
    public class MyJobLogger: ILog
    {
        private readonly ILog[] _loggers;
        private readonly Dictionary<LogLevel, bool> _logLevelConfig = new Dictionary<LogLevel, bool>();

        public MyJobLogger(ILog[] loggers, bool canLogInfo, bool canLogWarning, bool canLogError)
        {
            _loggers = loggers;
            _logLevelConfig.Add(LogLevel.Info, canLogInfo);
            _logLevelConfig.Add(LogLevel.Warning, canLogWarning);
            _logLevelConfig.Add(LogLevel.Error, canLogError);
        }

        public void Log(string message, LogLevel level)
        {
            ValidateConfig();
            ValidateInput(message, level);

            foreach (var logger in _loggers)
            {
                var canLogThis = _logLevelConfig[level];
                if (canLogThis)
                {
                    logger.Log(message, level);
                }
            }
        }


        private void ValidateConfig()
        {
            if (_logLevelConfig.All(x => !x.Value))
            {
                throw new LoggerException("Error or Warning or Message must be specified");
            }
        }

        private void ValidateInput(string message, LogLevel level)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new LoggerException("Message can't be empty");
            }

            if (_loggers == null)
            {
                throw new LoggerException("Invalid configuration");
            }

            if (!level.IsValid())
            {
                throw new LoggerException("Invalid level");
            }
        }
    }

    public class LoggerException : Exception
    {
        public LoggerException(string message) : base(message)
        {
        }
    }
}
