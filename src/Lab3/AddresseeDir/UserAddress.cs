using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;
using Itmo.ObjectOrientedProgramming.Lab3.UserDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;

public class UserAddress : IAddressee
{
    public User User { get; }

    public void SendMessage(Message message)
    {
        User.SendMessage(message);
    }

    public UserAddress(User user)
    {
        User = user;
    }
}