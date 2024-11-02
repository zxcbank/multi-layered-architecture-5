using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class SubjectBuilder
{
    private IReadOnlyCollection<Labwork>? _labworks;

    private IReadOnlyCollection<Lecture>? _lectures;

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

    public SubjectBuilder AddLabworks(IEnumerable<Labwork> labworks)
    {
        _labworks = labworks.ToList();
        return this;
    }

    public SubjectBuilder AddLectures(IEnumerable<Lecture> obj)
    {
        _lectures = obj.ToList();
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

    public CreateSubjectResult AddBaseSubject(Subject otherSubject, IdGenerator idGen)
    {
        _baseid = otherSubject.Id;
        _name = otherSubject.Name;
        _lectures = otherSubject.Lectures;
        _labworks = otherSubject.Labworks;
        return Build(idGen);
    }

    public CreateSubjectResult Build(IdGenerator idGen)
    {
        var potentialSubject = new Subject(
            _labworks ?? throw new InvalidOperationException(),
            _lectures ?? throw new InvalidOperationException(),
            _subjectType ?? throw new InvalidOperationException(),
            _name ?? throw new InvalidOperationException(),
            _user ?? throw new InvalidOperationException(),
            idGen,
            _baseid);

        return _subjectType.Validate(_labworks)
            ? new CreateSubjectResult.Success(potentialSubject)
            : new CreateSubjectResult.WrongPointsSumm();
    }
}