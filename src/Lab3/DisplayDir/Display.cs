using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;
using static Crayon.Output;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDir;

public class Display
{
    public Message? Text { get; set; }

    public Tuple<byte, byte, byte>? Color { get; set; }

    public void SendMessage(Message message)
    {
        Text = message;
    }

    public bool HasMessage(Message message)
    {
        return Text == message;
    }

    public void Print()
    {
        if (Color != null && Text != null)
            Console.WriteLine(Rgb(Color.Item1, Color.Item2, Color.Item3).Text(Text.Body));
    }
}