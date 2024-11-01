using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class EducationalProgrammBuilder
{
    private IReadOnlyCollection<ObjRepo<Subject>>? _subjects;

    private string? _name;

    private IUser? _user;

    public EducationalProgrammBuilder() { }

    public EducationalProgrammBuilder(IUser user)
    {
        _user = user;
    }

    public EducationalProgrammBuilder AddSubjects(IReadOnlyCollection<ObjRepo<Subject>> subjects)
    {
        _subjects = subjects;
        return this;
    }

    public EducationalProgrammBuilder AddName(string name)
    {
        _name = name;
        return this;
    }

    public EducationalProgrammBuilder AddUser(IUser user)
    {
        _user = user;
        return this;
    }

    public IHasId Build()
    {
        return new EducationalProgramm(
            _name ?? throw new InvalidOperationException(),
            _subjects ?? throw new InvalidOperationException(),
            _user ?? throw new InvalidOperationException());
    }
}