using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface ISubjectType
{
    public bool Validate(ObjRepo<Labwork> labworks);
}