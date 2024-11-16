namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class IdGenerator
{
    private long currentId = 0;

    public long GenericIdentity()
    {
        return currentId++;
    }
}