using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class DisplayDriver : IDriver
{
    private readonly Display display;

    public DisplayDriver(Display display)
    {
        this.display = display;
    }

    public void Flush()
    {
        display.Text = null;
    }

    public void SetColor()
    {
        throw new NotImplementedException();
    }

    public void SetText(Message message)
    {
        display.GetMessage(message);
    }
}