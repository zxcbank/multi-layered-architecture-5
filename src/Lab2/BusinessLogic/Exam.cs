using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class Exam : ISubjectType
{
    public int Points { get; }

    public bool Validate(ObjRepo<Labwork> labworks)
    {
        int labsPoints = labworks?.Items.Sum(x => x.Points) ?? 0;
        return (labsPoints + Points) == 100;
    }

    public Exam(int points)
    {
        Points = points;
    }
}