using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class Labwork : IHasId
{
    public static LabworkBuilder Labworkbuilder => new LabworkBuilder();

    private static readonly IdGenerator IdGen = new IdGenerator();

    public int Id { get; private set; }

    public int? BaseID { get; private set; }

    public string Name { get; private set; }

    public string Criteria { get; private set; }

    public string Description { get; private set; }

    public int Points { get; }

    public User Author { get; }

    public Labwork(
        int? baseid,
        string name,
        User author,
        string criteria,
        string description,
        int points)
    {
        Name = name;
        BaseID = baseid;
        Description = description;
        Criteria = criteria;
        Author = author;
        Points = points;
        Id = IdGen.GenericIdentity();
    }

    public ChangeLabworkResult ChangeName(
        User user,
        string name)
    {
        if (!user.Equals(Author))
        {
            return new ChangeLabworkResult.WrongAuthor();
        }
        else
        {
            Name = name;
        }

        return new ChangeLabworkResult.Success();
    }

    public ChangeLabworkResult ChangeDescrption(
        User user,
        string description)
    {
        if (!user.Equals(Author))
        {
            return new ChangeLabworkResult.WrongAuthor();
        }
        else
        {
            Description = description;
        }

        return new ChangeLabworkResult.Success();
    }

    public ChangeLabworkResult ChangeCriteria(
        User user,
        string criteria)
    {
        if (!user.Equals(Author))
        {
            return new ChangeLabworkResult.WrongAuthor();
        }
        else
        {
            Criteria = criteria;
        }

        return new ChangeLabworkResult.Success();
    }
}