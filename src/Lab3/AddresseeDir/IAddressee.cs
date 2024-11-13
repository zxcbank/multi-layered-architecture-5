using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;

public interface IAddressee
{
    void SendMessage(Message message);

    bool HasMessage(Message message);
}