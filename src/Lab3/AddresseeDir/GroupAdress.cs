using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;

public class GroupAdress : IAddressee
{
    private readonly List<IAddressee> _list;

    public GroupAdress(IReadOnlyCollection<IAddressee> list)
    {
        _list = list.ToList();
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IAddressee adressee in _list)
        {
            adressee.ReceiveMessage(message);
        }
    }
}