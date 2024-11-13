using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class Display : IAddressee
{
    public Message? Text { get; set; }

    public void GetMessage(Message message)
    {
        Text = message;
    }
}