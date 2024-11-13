using Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.TopicDir;

public class Topic(string name, IReadOnlyCollection<IAddressee> addressees)
{
    private readonly List<IAddressee> addressees = addressees.ToList();

    public string Name { get; private set; } = name;

    public void SendMessage(Message message)
    {
        foreach (IAddressee addres in addressees)
        {
            addres.GetMessage(message);
        }
    }

    public Topic AddAdrressee(IAddressee adressee)
    {
        addressees.Add(adressee);
        return this;
    }
}