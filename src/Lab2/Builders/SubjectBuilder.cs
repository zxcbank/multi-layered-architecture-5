using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class SubjectBuilder
{
    private ObjRepo<Labwork>? _labworks;

    private ObjRepo<Lecture>? _lectures;

    private ISubjectType? _subjectType;

    private string? _name;

    private User? _user;

    private int? _baseid;

    public SubjectBuilder()
    {
        _labworks = null;
        _lectures = null;
        _subjectType = null;
        _name = null;
        _user = null;
        _baseid = null;
    }

    public SubjectBuilder(User user)
    {
        _labworks = null;
        _lectures = null;
        _subjectType = null;
        _name = null;
        _user = user;
        _baseid = null;
    }

    public SubjectBuilder AddLabworks(ObjRepo<Labwork> labworks)
    {
        _labworks = labworks;
        return this;
    }

    public SubjectBuilder AddLectures(ObjRepo<Lecture> obj)
    {
        _lectures = obj;
        return this;
    }

    public SubjectBuilder AddSubjectType(ISubjectType type)
    {
        _subjectType = type;
        return this;
    }

    public SubjectBuilder AddName(string name)
    {
        _name = name;
        return this;
    }

    public SubjectBuilder AddUser(User user)
    {
        _user = user;
        return this;
    }

    public CreateSubjectResult AddBaseSubject(Subject otherSubject)
    {
        _baseid = otherSubject.Id;
        _name = otherSubject.Name;
        _lectures = otherSubject.Lectures;
        _labworks = otherSubject.Labworks;
        return Build();
    }

    public CreateSubjectResult Build()
    {
        var potentialSubject = new Subject(
            _labworks ?? throw new ArgumentNullException("labworks"),
            _lectures ?? throw new ArgumentNullException("lectures"),
            _subjectType ?? throw new ArgumentNullException("SubjectType"),
            _name ?? throw new ArgumentNullException("name"),
            _user ?? throw new ArgumentNullException("user"),
            _baseid);

        return _subjectType.Validate(_labworks)
            ? new CreateSubjectResult.Success(potentialSubject)
            : new CreateSubjectResult.WrongPointsSumm();
    }
}