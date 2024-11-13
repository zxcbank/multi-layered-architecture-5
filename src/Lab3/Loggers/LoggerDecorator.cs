using Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class LoggerDecorator : IAddressee
{
    public LoggerDecorator(IAddressee decoratee, ILogger logger)
    {
        _decoratee = decoratee;
        _logger = logger;
    }

    private readonly IAddressee _decoratee;

    private readonly ILogger _logger;

    public void SendMessage(Message message)
    {
        _logger.Log(message);
        _decoratee.SendMessage(message);
    }

    public bool HasMessage(Message message)
    {
        return _decoratee.HasMessage(message);
    }
}