using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.MessageLogic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class DisplayAdress : IAddressee
{
    public DisplayAdress(IDisplay display)
    {
        Display = display;
    }

    private IDisplay Display { get; }

    public void ReceiveMessage(Message message)
    {
        string text =
            $"|display| : Header: {message.Header} \n Body: {message.Body} \n Priority: {message.PriorityLevel}";
        Display.RececiveMesage(text);
    }
}