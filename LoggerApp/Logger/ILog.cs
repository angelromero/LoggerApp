namespace LoggerApp.Logger
{
    public interface ILog
    {
        void Log(string message, LogLevel level);
    }
}

public enum LogLevel
{
    Info = 1, Error = 2, Warning = 3
}

public static class LogLevelExtensions
{
    public static bool IsInfo(this LogLevel level)
    {
        return level == LogLevel.Info;
    }

    public static bool IsWarning(this LogLevel level)
    {
        return level == LogLevel.Warning;
    }

    public static bool IsError(this LogLevel level)
    {
        return level == LogLevel.Error;
    }

    public static bool IsValid(this LogLevel level)
    {
        return level.IsError() || level.IsInfo() || level.IsWarning();
    }
}