using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class Lecture : IHasId
{
    public static LectureBuilder Lecturekbuilder => new LectureBuilder();

    public long Id { get; private set; }

    public long? BaseID { get; private set; }

    public string Name { get; private set; }

    public string Criteria { get; private set; }

    public string Description { get; private set; }

    private User Author { get; }

    public Lecture(
        long? baseid,
        string name,
        User author,
        string criteria,
        string description,
        IdGenerator idGenerator)
    {
        Name = name;
        BaseID = baseid;
        Description = description;
        Criteria = criteria;
        Author = author;
        Id = idGenerator.GenericIdentity();
    }

    public ChangeLectureResult ChangeName(
        User user,
        string name)
    {
        if (!user.Equals(Author))
        {
            return new ChangeLectureResult.WrongAuthor();
        }
        else
        {
            Name = name;
        }

        return new ChangeLectureResult.Success();
    }

    public ChangeLectureResult ChangeDescrption(
        User user,
        string description)
    {
        if (!user.Equals(Author))
        {
            return new ChangeLectureResult.WrongAuthor();
        }
        else
        {
            Description = description;
        }

        return new ChangeLectureResult.Success();
    }

    public ChangeLectureResult ChangeCriteria(
        User user,
        string criteria)
    {
        if (!user.Equals(Author))
        {
            return new ChangeLectureResult.WrongAuthor();
        }
        else
        {
            Criteria = criteria;
        }

        return new ChangeLectureResult.Success();
    }
}