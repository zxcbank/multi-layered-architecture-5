namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class Messanger : IAddressee
{
    private Message.Message? _message;

    public void GetMessage(Message.Message message)
    {
        _message = message;
    }

    public void PrintMessage()
    {
        Console.WriteLine("|Messanger| : {0}", _message);
    }
}