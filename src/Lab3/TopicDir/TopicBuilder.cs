using Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.TopicDir;

public class TopicBuilder
{
    private List<IAddressee>? addressees;

    private string? name;

    public TopicBuilder()
    {
        addressees = null;
        name = null;
    }

    public TopicBuilder AddName(string name)
    {
        this.name = name;
        return this;
    }

    public TopicBuilder AddAdressees(IReadOnlyCollection<IAddressee> addressees)
    {
        this.addressees = addressees.ToList();
        return this;
    }

    public TopicDir.Topic Build()
    {
        return new TopicDir.Topic(
            name ?? throw new Exception(),
            addressees ?? throw new Exception());
    }
}