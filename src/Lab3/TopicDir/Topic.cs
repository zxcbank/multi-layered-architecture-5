using Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.TopicDir;

public class Topic
{
    public Topic(string name, IReadOnlyCollection<IAddressee> addressees)
    {
        Name = name;
        Addressees = addressees;
    }

    public IReadOnlyCollection<IAddressee> Addressees { get; }

    public string Name { get; private set; }

    public void ReceiveMessage(Message message)
    {
        foreach (IAddressee addres in Addressees)
        {
            addres.ReceiveMessage(message);
        }
    }
}