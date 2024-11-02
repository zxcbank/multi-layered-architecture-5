using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public class SubjectFactory
{
    private readonly User _author;

    public SubjectFactory(User author)
    {
        _author = author;
    }

    public SubjectBuilder Create()
    {
        return new SubjectBuilder(_author);
    }
}