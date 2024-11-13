using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;
using static Crayon.Output;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class Display : IAddressee
{
    public Message? Text { get; set; }

    public Tuple<byte, byte, byte>? Color { get;  set; }

    public void GetMessage(Message message)
    {
        Text = message;
    }

    public void Print()
    {
        if (Color != null) Console.WriteLine(Rgb(Color.Item1, Color.Item2, Color.Item3));
    }
}