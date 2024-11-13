using Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.GroupDir;

public class Group : IAddressee
{
    private readonly List<IAddressee> _list;

    private Message? _message;

    public void GetMessage(Message message)
    {
        _message = message;
    }

    public void TransferMessage()
    {
        foreach (IAddressee adressee in _list)
        {
            if (_message != null) this.GetMessage(_message);
        }
    }

    public Group(IReadOnlyCollection<IAddressee> list)
    {
        _list = list.ToList();
    }
}