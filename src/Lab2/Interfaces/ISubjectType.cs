using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface ISubjectType
{
    public CreateSubjectResult Validate(IDictionary<long, Labwork> labworks);
}