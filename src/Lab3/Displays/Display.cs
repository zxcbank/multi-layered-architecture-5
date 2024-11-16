namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    public IDriver Driver { get; }

    public Display(IDriver driver)
    {
        Driver = driver;
    }

    public void Print()
    {
        Driver.Print();
    }
}