using Itmo.ObjectOrientedProgramming.Lab3.MessageLogic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public interface IAddressee
{
    void ReceiveMessage(Message message);
}