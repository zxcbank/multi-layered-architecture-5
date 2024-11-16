using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class Zachet : ISubjectType
{
    public CreateSubjectResult Validate(IDictionary<long, Labwork> labworks)
    {
        int labsPoints = labworks.Values.Sum(x => x.Points);
        if (labsPoints == Subject.Maxpoints)
            return new CreateSubjectResult.ValidateSuccess();
        return new CreateSubjectResult.ValidateFail();
    }

    public int MinPoints { get; }

    public Zachet(int minpoints)
    {
        MinPoints = minpoints;
    }
}