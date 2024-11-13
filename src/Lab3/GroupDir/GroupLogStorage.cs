using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.GroupDir;

public class GroupLogStorage : ILogger
{
    private readonly List<Message> _logs;

    public GroupLogStorage()
    {
        _logs = new List<Message>();
    }

    public void Log(Message message)
    {
        _logs.Add(message);
    }
}