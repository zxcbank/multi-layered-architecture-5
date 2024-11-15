using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;
using Itmo.ObjectOrientedProgramming.Lab3.MessengerDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;

public class MessengerAddress : IAddressee
{
    public Messenger Messenger { get; }

    public void SendMessage(Message message)
    {
        Messenger.SendMessage(message);
    }

    public MessengerAddress(Messenger messenger)
    {
        Messenger = messenger;
    }
}