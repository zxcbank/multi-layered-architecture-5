using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Results;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class Subject : IHasId
{
    public Subject(
        ReadOnlyCollection<Labwork> labworks,
        ReadOnlyCollection<Lecture> lectures,
        ISubjectType subjectype,
        string name,
        User user,
        IdGenerator idGenerator,
        long? baseid)
    {
        Labworks = labworks.AsReadOnly();
        Lectures = lectures.AsReadOnly();
        SubjType = subjectype;
        Name = name;
        User = user;
        Id = idGenerator.GenericIdentity();
        Baseid = baseid;
    }

    public static int Maxpoints { get; } = 100;

    public ReadOnlyCollection<Labwork> Labworks { get; private set; }

    public ReadOnlyCollection<Lecture> Lectures { get; private set; }

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
        ReadOnlyCollection<Lecture> lectures)
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