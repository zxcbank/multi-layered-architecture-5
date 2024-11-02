using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class EducationalProgrammBuilder
{
    private ObjRepo<ScheduleModule>? _subjects;

    private string? _name;

    private User? _user;

    public EducationalProgrammBuilder() { }

    public EducationalProgrammBuilder(User user)
    {
        _user = user;
    }

    public EducationalProgrammBuilder AddSubjects(ObjRepo<ScheduleModule> subjects)
    {
        _subjects = subjects;
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

    public EducationalProgramm Build()
    {
        return new EducationalProgramm(
            _name ?? throw new ArgumentNullException(),
            _subjects ?? throw new ArgumentNullException(),
            _user ?? throw new ArgumentNullException());
    }
}