using Itmo.ObjectOrientedProgramming.Lab3.MessageLogic;
using Itmo.ObjectOrientedProgramming.Lab3.UserLogic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class UserAddress : IAddressee
{
    public UserAddress(User user)
    {
        User = user;
    }

    private User User { get; }

    public void ReceiveMessage(Message message)
    {
        User.ReceiveMessage(message);
    }
}