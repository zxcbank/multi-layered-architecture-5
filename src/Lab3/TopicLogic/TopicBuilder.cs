using Itmo.ObjectOrientedProgramming.Lab3.Addressees;

namespace Itmo.ObjectOrientedProgramming.Lab3.TopicLogic;

public class TopicBuilder
{
    private List<IAddressee>? _addressees;

    private string? _name;

    public TopicBuilder()
    {
        _addressees = null;
        _name = null;
    }

    public TopicBuilder AddName(string name)
    {
        _name = name;
        return this;
    }

    public TopicBuilder AddAdressees(IReadOnlyCollection<IAddressee> addressees)
    {
        _addressees = addressees.ToList();
        return this;
    }

    public Topic Build()
    {
        return new Topic(
            _name ?? throw new Exception(),
            _addressees ?? throw new Exception());
    }
}