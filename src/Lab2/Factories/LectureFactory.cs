using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public class LectureFactory
{
    private readonly User _author;

    public LectureFactory(User author)
    {
        _author = author;
    }

    public LectureBuilder Create()
    {
        return new LectureBuilder(_author);
    }
}