using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class EducationalProgrammBuilder
{
    private readonly Dictionary<int, List<Subject>> _subjects = [];
    private string? _name;
    private User? _user;

    public EducationalProgrammBuilder(User user)
    {
        _user = user;
    }

    public EducationalProgrammBuilder AddSubjects(int semester, Subject subject)
    {
        _subjects[semester].Add(subject);
        return this;
    }

    public EducationalProgrammBuilder AddName(string name)
    {
        _name = name;
        return this;
    }

    public EducationalProgrammBuilder AddUser(User user)
    {
        _user = user;
        return this;
    }

    public EducationalProgramm Build(IdGenerator idGenerator)
    {
        return new EducationalProgramm(
            _name ?? throw new InvalidOperationException(),
            _subjects ?? throw new InvalidOperationException(),
            _user ?? throw new InvalidOperationException(),
            idGenerator);
    }
}