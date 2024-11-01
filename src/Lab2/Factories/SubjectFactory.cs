using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public class SubjectFactory
{
    private readonly IUser _author;

    public SubjectFactory(IUser author)
    {
        _author = author;
    }

    public SubjectBuilder Create()
    {
        return new SubjectBuilder(_author);
    }
}