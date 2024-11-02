using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class EducationalProgramm : IHasId
{
    public static EducationalProgrammBuilder Builder => new EducationalProgrammBuilder();

    private static readonly IdGenerator IdGen = new IdGenerator();

    public ObjRepo<ScheduleModule> Subjects { get; private set; }

    public string Name { get; private set; }

    public User User { get; private set; }

    public int Id { get; private set; }

    public EducationalProgramm(
        string name,
        ObjRepo<ScheduleModule> subjects,
        User user)
    {
        Id = IdGen.GenericIdentity();
        Subjects = subjects;
        User = user;
        Name = name;
    }
}