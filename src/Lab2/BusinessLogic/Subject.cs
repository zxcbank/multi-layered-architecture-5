using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class Subject : IIdentifiable
{
    public Subject(
        Dictionary<long, Labwork> labworks,
        Dictionary<long, Lecture> lectures,
        ISubjectType subjectype,
        string name,
        User user,
        IdGenerator idGenerator,
        long? baseid)
    {
        Labworks = labworks;
        Lectures = lectures;
        SubjType = subjectype;
        Name = name;
        User = user;
        Id = idGenerator.GenericIdentity();
        Baseid = baseid;
    }

    public static int Maxpoints { get; } = 100;

    public Dictionary<long, Labwork> Labworks { get; private set; }

    public Dictionary<long, Lecture> Lectures { get; private set; }

    public ISubjectType SubjType { get; private set; }

    public string Name { get; private set; }

    public User User { get; private set; }

    public long? Baseid { get; private set; }

    public long Id { get; private set; }

    public ChangeSubjectResult ChangeName(
        User user,
        string name)
    {
        if (!user.Equals(User))
        {
            return new ChangeSubjectResult.WrongAuthor();
        }
        else
        {
            Name = name;
        }

        return new ChangeSubjectResult.Success();
    }

    public ChangeSubjectResult ChangeLectures(
        User user,
        Dictionary<long, Lecture> lectures)
    {
        if (!user.Equals(User))
        {
            return new ChangeSubjectResult.WrongAuthor();
        }
        else
        {
            Lectures = lectures;
        }

        return new ChangeSubjectResult.Success();
    }
}