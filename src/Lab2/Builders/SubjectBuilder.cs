using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Results;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class SubjectBuilder
{
    private List<Labwork> _labworks = [];
    private List<Lecture> _lectures = [];
    private ISubjectType? _subjectType;
    private string? _name;
    private User? _user;
    private long? _baseid;

    public SubjectBuilder()
    {
        _subjectType = null;
        _name = null;
        _user = null;
        _baseid = null;
    }

    public SubjectBuilder(User user)
    {
        _subjectType = null;
        _name = null;
        _user = user;
        _baseid = null;
    }

    public SubjectBuilder AddLabworks(ReadOnlyCollection<Labwork> labworks)
    {
        _labworks = labworks.ToList();
        return this;
    }

    public SubjectBuilder AddLectures(ReadOnlyCollection<Lecture> lecture)
    {
        _lectures = lecture.ToList();
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
        _lectures = otherSubject.Lectures.ToList();
        _labworks = otherSubject.Labworks.ToList();
        return Build(idGenerator);
    }

    public CreateSubjectResult Build(IdGenerator idGenerator)
    {
        var potentialSubject = new Subject(
            _labworks.AsReadOnly() ?? throw new InvalidOperationException(),
            _lectures.AsReadOnly() ?? throw new InvalidOperationException(),
            _subjectType ?? throw new InvalidOperationException(),
            _name ?? throw new InvalidOperationException(),
            _user ?? throw new InvalidOperationException(),
            idGenerator,
            _baseid);

        return _subjectType.Validate(_labworks)
            ? new CreateSubjectResult.Success(potentialSubject)
            : new CreateSubjectResult.WrongPointsSumm();
    }
}