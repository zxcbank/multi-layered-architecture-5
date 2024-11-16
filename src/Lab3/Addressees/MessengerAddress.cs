using Itmo.ObjectOrientedProgramming.Lab3.MessageLogic;
using Itmo.ObjectOrientedProgramming.Lab3.MessengerLogic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class MessengerAddress : IAddressee
{
    public MessengerAddress(Messenger messenger)
    {
        Messenger = messenger;
    }

    private Messenger Messenger { get; }

    public void ReceiveMessage(Message message)
    {
        Messenger.ReceiveMessage(message);
    }
}