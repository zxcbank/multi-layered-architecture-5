using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class Subject : IHasId
{
    public static SubjectBuilder SbBuilder => new SubjectBuilder();

    public ObjRepo<Labwork> Labworks { get; private set; }

    public ObjRepo<Lecture> Lectures { get; private set; }

    public SubjectType SubjType { get; private set; }

    public string Name { get; private set; }

    public IUser User { get; private set; }

    public Guid? Baseid { get; private set; }

    public Guid Id { get; private set; }

    public Subject(
        ObjRepo<Labwork> labworks,
        ObjRepo<Lecture> lectures,
        SubjectType subjectype,
        string name,
        IUser user,
        Guid? baseid)
    {
        Labworks = labworks;
        Lectures = lectures;
        SubjType = subjectype;
        Name = name;
        User = user;
        Id = Guid.NewGuid();
        Baseid = baseid;
    }

    public ChangeSubjectResult ChangeName(
        IUser user,
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
        IUser user,
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