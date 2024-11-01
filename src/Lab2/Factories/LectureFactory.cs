using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public class LectureFactory : IObjFactory
{
    private readonly IUser _author;

    public LectureFactory(IUser author)
    {
        _author = author;
    }

    public IBuilder Create()
    {
        return new LectureBuilder(_author);
    }
}