using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    public IDriver Driver { get; }

    public Display(IDriver driver)
    {
        Driver = driver;
    }

    public void SetColor(Color color)
    {
        Driver.SetColor(color);
    }

    public void RececiveMesage(string displayMessage)
    {
        Driver.Flush();
        Driver.SetText(displayMessage);
        Driver.Print();
    }
}