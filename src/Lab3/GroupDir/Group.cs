using Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.GroupDir;

public class Group : IAddressee
{
    private readonly List<IAddressee> _list;

    private Message? _message;

    public void SendMessage(Message message)
    {
        _message = message;
    }

    public bool HasMessage(Message message)
    {
        return _list.Any(addr => addr.HasMessage(message));
    }

    public void TransferMessage()
    {
        foreach (IAddressee adressee in _list)
        {
            if (_message != null) this.SendMessage(_message);
        }
    }

    public Group(IReadOnlyCollection<IAddressee> list)
    {
        _list = list.ToList();
    }
}