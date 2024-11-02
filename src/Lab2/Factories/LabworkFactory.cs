using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public class LabworkFactory
{
    private readonly User _author;

    public LabworkFactory(User author)
    {
        _author = author;
    }

    public LabworkBuilder Create()
    {
        return new LabworkBuilder(_author);
    }
}