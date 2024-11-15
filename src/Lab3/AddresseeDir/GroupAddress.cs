using Itmo.ObjectOrientedProgramming.Lab3.GroupDir;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;

public class GroupAddress
{
    public Group Messenger { get; }

    public void SendMessage(Message message)
    {
        Messenger.SendMessage(message);
    }

    public GroupAddress(Group messenger)
    {
        Messenger = messenger;
    }
}