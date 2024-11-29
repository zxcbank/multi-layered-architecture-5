using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsLogic.Builders;

public interface IBuilder
{
    public ICommand Build();

    public IBuilder AddFLag(string flag, string value);

    public IBuilder AddSource(string source);

    public IBuilder AddDestination(string destination);

    public IBuilder AddPath(string path);

    public IBuilder AddName(string name);
}