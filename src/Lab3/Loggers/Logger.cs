namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class Logger : ILogger
{
    private readonly List<string> _logs;

    public Logger()
    {
        _logs = new List<string>();
    }

    public void Log(string logmessage)
    {
        _logs.Add(logmessage);
    }
}