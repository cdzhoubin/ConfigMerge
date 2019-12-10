namespace ConfigMerge.Services.Logging
{
    public class ConsoleLoggerCreator : ILoggerCreator
    {
        public ILogger Create(string name)
        {
            return new ConsoleLogger(name);
        }
    }
}