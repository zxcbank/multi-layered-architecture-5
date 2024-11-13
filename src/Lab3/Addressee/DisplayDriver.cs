using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class DisplayDriver : IDriver
{
    private readonly Display display;

    private readonly Tuple<byte, byte, byte> color;

    public DisplayDriver(Display customdisplay, byte r, byte g, byte b)
    {
        display = customdisplay;
        color = new Tuple<byte, byte, byte>(r, g, b);
    }

    public void Flush()
    {
        display.Text = null;
    }

    public void SetColor()
    {
        display.Color = color;
    }

    public void SetText(Message message)
    {
        display.GetMessage(message);
    }
}