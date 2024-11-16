using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public class EducationBuilderFactory
{
    private readonly User _author;

    public EducationBuilderFactory(User author)
    {
        _author = author;
    }

    public EducationalProgrammBuilder Create()
    {
        return new EducationalProgrammBuilder(_author);
    }
}