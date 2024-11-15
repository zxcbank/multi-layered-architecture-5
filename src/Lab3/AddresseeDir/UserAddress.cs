using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;
using Itmo.ObjectOrientedProgramming.Lab3.UserDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;

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