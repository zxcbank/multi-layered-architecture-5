namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class IdGenerator
{
    private int currentId = 0;

    public int GenericIdentity()
    {
        return currentId++;
    }
}