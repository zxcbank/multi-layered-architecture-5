namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class DisplayDriver : IDriver
{
    private readonly Display _display;

    public DisplayDriver(Display display)
    {
        _display = display;
    }

    public void Flush()
    {
        _display.Text = null;
    }

    public void SetColor()
    {
        throw new NotImplementedException();
    }

    public void SetText(Message.Message message)
    {
        _display.GetMessage(message);
    }
}