namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class IdGenerator
{
    private static int currentId = 0;

    public static int GenericIdentity()
    {
        return currentId++;
    }
}