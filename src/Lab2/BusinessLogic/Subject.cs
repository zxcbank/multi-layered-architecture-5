using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class Subject : IHasId
{
    public IReadOnlyCollection<Labwork> Labworks { get; private set; }

    public IReadOnlyCollection<Lecture> Lectures { get; private set; }

    public ISubjectType SubjType { get; private set; }

    public string Name { get; private set; }

    public User User { get; private set; }

    public int? Baseid { get; private set; }

    public int Id { get; private set; }

    public Subject(
        IEnumerable<Labwork> labworks,
        IEnumerable<Lecture> lectures,
        ISubjectType subjectype,
        string name,
        User user,
        IdGenerator idGen,
        int? baseid)
    {
        Labworks = labworks.ToList();
        Lectures = lectures.ToList();
        SubjType = subjectype;
        Name = name;
        User = user;
        Id = idGen.GenericIdentity();
        Baseid = baseid;
    }

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
        IEnumerable<Lecture> lectures)
    {
        if (!user.Equals(User))
        {
            return new ChangeSubjectResult.WrongAuthor();
        }
        else
        {
            Lectures = lectures.ToList();
        }

        return new ChangeSubjectResult.Success();
    }
}