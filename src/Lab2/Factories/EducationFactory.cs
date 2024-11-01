using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public class EducationFactory
{
    private readonly IUser _author;

    public EducationFactory(IUser author)
    {
        _author = author;
    }

    public EducationalProgrammBuilder Create()
    {
        return new EducationalProgrammBuilder(_author);
    }
}