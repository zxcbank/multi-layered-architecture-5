using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;

public class FilterProxy : IAddressee
{
    private readonly Func<Priority, bool> _filter;

    private readonly IAddressee _adressee;

    public FilterProxy(Func<Priority, bool> filter, IAddressee adressee)
    {
        _adressee = adressee;
        _filter = filter;
    }

    public void SendMessage(Message message)
    {
        if (_filter(message.PriorityLevel))
        {
            _adressee.SendMessage(message);
        }
    }
}