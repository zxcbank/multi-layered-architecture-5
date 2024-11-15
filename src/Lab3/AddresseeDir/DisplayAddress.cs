using Itmo.ObjectOrientedProgramming.Lab3.DisplayDir;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;

public class DisplayAddress : IAddressee
{
    public Display Dis { get; }

    public void SendMessage(Message message)
    {
        Dis.SendMessage(message);
    }

    public DisplayAddress(Display dis)
    {
        Dis = dis;
    }
}