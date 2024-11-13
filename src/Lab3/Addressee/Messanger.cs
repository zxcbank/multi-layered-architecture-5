using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class Messanger : IAddressee
{
    private Message? message;

    public void GetMessage(Message message)
    {
        this.message = message;
    }

    public void PrintMessage()
    {
        Console.WriteLine("|Messanger| : {0}", message);
    }
}