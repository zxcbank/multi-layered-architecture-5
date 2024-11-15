using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;
using static Crayon.Output;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDir;

public class Display : IPrintable
{
    public DisplayDriver Driver { get; private set; }

    public Display(DisplayDriver displydriver)
    {
        Driver = displydriver;
    }

    public void SendMessage(Message message)
    {
        Driver.SendMessage(message);
    }

    public void Print()
    {
        if (Driver is { Color: not null, Text: not null })
        {
            string consoleText = $"{Driver.Text.Header} \n {Driver.Text.Body}";
            Console.WriteLine(Rgb(Driver.Color.Item1, Driver.Color.Item2, Driver.Color.Item3).Text(consoleText));
        }
    }
}