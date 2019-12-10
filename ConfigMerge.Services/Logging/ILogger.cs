namespace ConfigMerge.Services.Logging
{
    public interface ILogger
    {
        void Log(LogLevel level, object message);
    }
}