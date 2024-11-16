using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class Exam : ISubjectType
{
    public int Points { get; }

    public CreateSubjectResult Validate(IDictionary<long, Labwork> labworks)
    {
        int labsPoints = labworks.Values.Sum(x => x.Points);
        if ((labsPoints + Points) == Subject.Maxpoints)
            return new CreateSubjectResult.ValidateSuccess();
        return new CreateSubjectResult.ValidateFail();
    }

    public Exam(int points)
    {
        Points = points;
    }
}