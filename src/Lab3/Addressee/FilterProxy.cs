using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class FilterProxy : IAddressee
{
    private readonly Priority _filter;

    private readonly IAddressee _adressee;

    public FilterProxy(Priority filter, IAddressee adressee)
    {
        _adressee = adressee;
        _filter = filter;
    }

    public void GetMessage(Message.Message message)
    {
        if (message.PriorityLevel == _filter)
        {
            _adressee.GetMessage(message);
        }
    }
}