using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDir;

public class DisplayDriver
{
    public Tuple<byte, byte, byte>? Color { get; private set; }

    public Message? Text { get; private set; }

    public void Flush(Message? message)
    {
        message = null;
    }

    public void SetColor(Tuple<byte, byte, byte> color)
    {
        Color = color;
    }

    public void SendMessage(Message message)
    {
        Text = message;
    }
}