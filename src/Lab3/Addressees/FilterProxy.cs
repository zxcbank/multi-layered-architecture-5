using Itmo.ObjectOrientedProgramming.Lab3.MessageLogic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class FilterProxy : IAddressee
{
    private readonly Func<int, bool> _filter;

    private readonly IAddressee _adressee;

    public FilterProxy(Func<int, bool> filter, IAddressee adressee)
    {
        _adressee = adressee;
        _filter = filter;
    }

    public void ReceiveMessage(Message message)
    {
        if (_filter(message.PriorityLevel))
        {
            _adressee.ReceiveMessage(message);
        }
    }
}