using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class LabworkBuilder
{
    private int? _points;

    private int? _baseId;

    private string? _name;

    private User? _author;

    private string? _criteria;

    private string? _description;

    public LabworkBuilder()
    {
        _baseId = null;
        _name = null;
        _author = null;
        _criteria = null;
        _description = null;
        _points = null;
    }

    public LabworkBuilder(User user)
    {
        _baseId = null;
        _name = null;
        _author = user;
        _criteria = null;
        _description = null;
        _points = null;
    }

    public Labwork AddBaseLabwork(Labwork otherLabwork)
    {
        _baseId = otherLabwork.Id;
        _name = otherLabwork.Name;
        _criteria = otherLabwork.Criteria;
        _points = otherLabwork.Points;
        _description = otherLabwork.Description;

        return Build();
    }

    public LabworkBuilder AddName(string name)
    {
        _name = name;
        return this;
    }

    public LabworkBuilder AddAuthor(User author)
    {
        _author = author;
        return this;
    }

    public LabworkBuilder AddCriteria(string criteria)
    {
        _criteria = criteria;
        return this;
    }

    public LabworkBuilder AddDescription(string description)
    {
        _description = description;
        return this;
    }

    public LabworkBuilder AddPoints(int points)
    {
        _points = points;
        return this;
    }

    public Labwork Build()
    {
        return new Labwork(
            _baseId,
            _name ?? throw new ArgumentNullException("name"),
            _author ?? throw new ArgumentNullException("author"),
            _criteria ?? throw new ArgumentNullException("criteria"),
            _description ?? throw new ArgumentNullException("description"),
            _points ?? throw new ArgumentNullException("points"));
    }
}