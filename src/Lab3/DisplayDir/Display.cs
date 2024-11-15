namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDir;

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