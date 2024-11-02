using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class Subject : IHasId
{
    public ObjRepo<Labwork> Labworks { get; private set; }

    public ObjRepo<Lecture> Lectures { get; private set; }

    public ISubjectType SubjType { get; private set; }

    public string Name { get; private set; }

    public User User { get; private set; }

    public int? Baseid { get; private set; }

    public int Id { get; private set; }

    public Subject(
        ObjRepo<Labwork> labworks,
        ObjRepo<Lecture> lectures,
        ISubjectType subjectype,
        string name,
        User user,
        int? baseid)
    {
        Labworks = labworks;
        Lectures = lectures;
        SubjType = subjectype;
        Name = name;
        User = user;
        Id = IdGenerator.GenericIdentity();
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
        ObjRepo<Lecture> lectures)
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