using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class Exam : ISubjectType
{
    public int Points { get; }

    public bool Validate(IEnumerable<Labwork> labworks)
    {
        int labsPoints = labworks.Sum(x => x.Points);
        return (labsPoints + Points) == 100;
    }

    public Exam(int points)
    {
        Points = points;
    }
}