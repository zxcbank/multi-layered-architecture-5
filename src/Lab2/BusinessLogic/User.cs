namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class User
{
    public int Id { get; private set; }

    public string Name { get; }

    public User(string name, IdGenerator idGen)
    {
        Id = idGen.GenericIdentity();
        Name = name;
    }

    public bool Equals(User a)
    {
        return this.Id == a.Id;
    }
}