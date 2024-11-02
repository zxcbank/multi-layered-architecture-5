using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class Zachet : ISubjectType
{
    public bool Validate(IEnumerable<Labwork> labworks)
    {
        int labsPoints = labworks.Sum(x => x.Points);
        return labsPoints == 100;
    }

    public int MinPoints { get; }

    public Zachet(int minpoints)
    {
        MinPoints = minpoints;
    }
}