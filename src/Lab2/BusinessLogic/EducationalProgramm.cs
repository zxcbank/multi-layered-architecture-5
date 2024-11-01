using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class EducationalProgramm : IHasId
{
    public static EducationalProgrammBuilder Builder => new EducationalProgrammBuilder();

    public IReadOnlyCollection<ObjRepo<Subject>> Subjects { get; set; }

    public string Name { get; private set; }

    public IUser User { get; private set; }

    public Guid Id { get; set; }

    public EducationalProgramm(
        string name,
        IReadOnlyCollection<ObjRepo<Subject>> subjects,
        IUser user)
    {
        Id = Guid.NewGuid();
        Subjects = subjects;
        User = user;
        Name = name;
    }
}