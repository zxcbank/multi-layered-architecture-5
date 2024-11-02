namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class User
{
    public int Id { get; private set; }

    public string Name { get; }

    public User(string name)
    {
        Id = IdGenerator.GenericIdentity();
        Name = name;
    }

    public User Clone()
    {
        var result = new User(Name);
        result.Id = Id;
        return result;
    }

    public bool Equals(User a)
    {
        return this.Id == a.Id;
    }
}