using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;
using Itmo.ObjectOrientedProgramming.Lab3.MessengerDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;

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