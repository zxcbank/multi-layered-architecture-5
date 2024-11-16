namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class User
{
    public long Id { get; private set; }

    public string Name { get; }

    public User(string name, IdGenerator idGenerator)
    {
        Id = idGenerator.GenericIdentity();
        Name = name;
    }

    public bool Equals(User a)
    {
        return this.Id == a.Id;
    }
}