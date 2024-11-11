using Itmo.ObjectOrientedProgramming.Lab3.Addressee;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topic;

public class Topic
{
    private readonly List<IAddressee> _addressees;

    public string Name { get; private set; }

    public void SendMessage(Message.Message message)
    {
        foreach (IAddressee addres in _addressees)
        {
            addres.GetMessage(message);
        }
    }

    public Topic AddAdrressee(IAddressee adressee)
    {
        _addressees.Add(adressee);
        return this;
    }

    public Topic(string name, IReadOnlyCollection<IAddressee> addressees)
    {
        Name = name;
        _addressees = addressees.ToList();
    }
}