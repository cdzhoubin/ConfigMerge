namespace ConfigMerge.Services.Logging
{
    public static class LoggerFactory{
        private static ILoggerCreator _loggerFunc = GetDefaultLoggerFunc();// => 
        private static ILoggerCreator GetDefaultLoggerFunc()
        {
            return new ConsoleLoggerCreator();
        }
        public static ILogger CreateLogger(string name)
        {
            return _loggerFunc.Create(name);
        }
        public static void SetLoggerFunction(ILoggerCreator loggerFunc)
        {
            if(loggerFunc != null)
            {
                _loggerFunc = loggerFunc;
            }
        }
        }
}