using Itmo.ObjectOrientedProgramming.Lab3.DisplayDir;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;

public class DisplayAdress : IAddressee
{
    public DisplayAdress(IDriver driver)
    {
        Driver = driver;
    }

    private IDriver Driver { get; }

    public void ReceiveMessage(Message message)
    {
        string text =
            $"|display| : Header: {message.Header} \n Body: {message.Body} \n Priority: {message.PriorityLevel}";
        Driver.SetText(text);
    }
}