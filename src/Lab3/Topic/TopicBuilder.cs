using Itmo.ObjectOrientedProgramming.Lab3.Addressee;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topic;

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

    public Topic Build()
    {
        return new Topic(
            name ?? throw new Exception(),
            addressees ?? throw new Exception());
    }
}