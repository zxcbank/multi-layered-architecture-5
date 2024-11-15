using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class EducationalProgramm : IHasId
{
    public Dictionary<int, List<Subject>> Subjects { get; private set; }

    public string Name { get; private set; }

    public User User { get; private set; }

    public long Id { get; private set; }

    public EducationalProgramm(
        string name,
        Dictionary<int, List<Subject>> subjects,
        User user,
        IdGenerator idGenerator)
    {
        Id = idGenerator.GenericIdentity();
        Subjects = subjects;
        User = user;
        Name = name;
    }
}