using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class SubjectBuilder
{
    private Dictionary<long, Labwork> _labworks = [];
    private Dictionary<long, Lecture> _lectures = [];
    private ISubjectType? _subjectType;
    private string? _name;
    private User? _user;
    private long? _baseid;

    public SubjectBuilder() { }

    public SubjectBuilder(User user)
    {
        _subjectType = null;
        _name = null;
        _user = user;
        _baseid = null;
    }

    public SubjectBuilder AddLabworks(Dictionary<long, Labwork> labworks)
    {
        _labworks = labworks;
        return this;
    }

    public SubjectBuilder AddLectures(Dictionary<long, Lecture> lecture)
    {
        _lectures = lecture;
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

    public CreateSubjectResult AddBaseSubject(Subject otherSubject, IdGenerator idGenerator)
    {
        _baseid = otherSubject.Id;
        _name = otherSubject.Name;
        _lectures = otherSubject.Lectures;
        _labworks = otherSubject.Labworks;
        return Build(idGenerator);
    }

    public CreateSubjectResult Build(IdGenerator idGenerator)
    {
        var potentialSubject = new Subject(
            _labworks ?? throw new InvalidOperationException(),
            _lectures ?? throw new InvalidOperationException(),
            _subjectType ?? throw new InvalidOperationException(),
            _name ?? throw new InvalidOperationException(),
            _user ?? throw new InvalidOperationException(),
            idGenerator,
            _baseid);

        return (_subjectType.Validate(_labworks) == new CreateSubjectResult.ValidateSuccess()) ? new CreateSubjectResult.Success(potentialSubject) : new CreateSubjectResult.WrongPointsSumm();
    }
}