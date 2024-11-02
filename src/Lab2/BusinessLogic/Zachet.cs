using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class Zachet : ISubjectType
{
    public bool Validate(ObjRepo<Labwork> labworks)
    {
        int labsPoints = labworks?.Items.Sum(x => x.Points) ?? 0;
        return labsPoints == 100;
    }

    public int MinPoints { get; }

    public Zachet(int minpoints)
    {
        MinPoints = minpoints;
    }
}