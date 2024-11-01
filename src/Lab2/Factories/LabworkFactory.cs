using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Factories;

public class LabworkFactory : IObjFactory
{
    private readonly IUser _author;

    public LabworkFactory(IUser author)
    {
        _author = author;
    }

    public IBuilder Create()
    {
        return new LabworkBuilder(_author);
    }
}