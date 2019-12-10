namespace ConfigMerge.Services.Logging
{
    public interface ILoggerCreator
    {
        ILogger Create(string name);
    }
}