using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.MessageLogic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class LoggerDecorator : IAddressee
{
    private readonly IAddressee _decoratee;

    private readonly ILogger _logger;

    public LoggerDecorator(IAddressee decoratee, ILogger logger)
    {
        _decoratee = decoratee;
        _logger = logger;
    }

    public void ReceiveMessage(Message message)
    {
        string logmessage =
            $"|Log| : Header: {message.Header} \n Body: {message.Body} \n Priority: {message.PriorityLevel}";
        _logger.Log(logmessage);
        _decoratee.ReceiveMessage(message);
    }
}