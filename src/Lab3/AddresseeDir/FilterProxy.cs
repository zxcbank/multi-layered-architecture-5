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

    public void GetMessage(Message message)
    {
        if (message.PriorityLevel == _filter)
        {
            _adressee.GetMessage(message);
        }
    }
}