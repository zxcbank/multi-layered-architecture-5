namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public record SubjectType
{
    private SubjectType() { }

    public sealed record Exam : SubjectType
    {
        public int Points { get;  }

        public Exam(int points)
        {
            Points = points;
        }
    }

    public sealed record Zachet : SubjectType
    {
        public int MinPoints { get;  }

        public Zachet(int minPoints)
        {
            MinPoints = minPoints;
        }
    }
}