namespace ConfigMerge.Services.Logging
{
    public static class LoggerExtensions
    {
        public static void TraceFormat(this ILogger logger, string format, params object[] messages)
        {
            logger.Log(LogLevel.Trace, string.Format(format, messages));
        }

        public static void DebugFormat(this ILogger logger, string format, params object[] messages)
        {
            logger.Log(LogLevel.Debug, string.Format(format, messages));
        }

        public static void LogFormat(this ILogger logger, string format, params object[] messages)
        {
            logger.Log(LogLevel.Normal, string.Format(format, messages));
        }

        public static void ImportantFormat(this ILogger logger,string format,params object[] messages)
        {
            logger.Log(LogLevel.Important,string.Format(format, messages));
        }
        public static void Trace(this ILogger logger, object message)
        {
            logger.Log(LogLevel.Trace, message);
        }

        public static void Debug(this ILogger logger, object message)
        {
            logger.Log(LogLevel.Debug, message);
        }

        public static void Log(this ILogger logger, object message)
        {
            logger.Log(LogLevel.Normal, message);
        }

        public static void Important(this ILogger logger, object message)
        {
            logger.Log(LogLevel.Important, message);
        }
    }
}