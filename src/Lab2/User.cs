namespace Itmo.ObjectOrientedProgramming.Lab2;

public class User : IUser
{
    public Guid Id { get; private set; }

    public string Name { get; }

    public User(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public IUser Clone()
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