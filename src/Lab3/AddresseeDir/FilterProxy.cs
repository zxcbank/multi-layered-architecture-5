using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;

public class FilterProxy : IAddressee
{
    private readonly Priority _filter;

    private readonly IAddressee _adressee;

    public FilterProxy(Priority filter, IAddressee adressee)
    {
        _adressee = adressee;
        _filter = filter;
    }

    public void SendMessage(Message message)
    {
        if (message.PriorityLevel.Value == _filter.Value)
        {
            _adressee.SendMessage(message);
        }
    }

    public bool HasMessage(Message message)
    {
        return _adressee.HasMessage(message);
    }
}