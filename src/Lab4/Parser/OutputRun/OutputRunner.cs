using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.OutputRun;

public class OutputRunner
{
    private readonly IParameterHandler _handler;

    public OutputRunner(IParameterHandler handler)
    {
        _handler = handler;
    }

    public void Run(IEnumerable<string> args, FileSystem fs)
    {
        using IEnumerator<string> request = args.GetEnumerator();

        while (request.MoveNext())
        {
            ICommand? command = _handler.Handle(request);
            if (command is not null)
            {
                command.Execute(fs);
                break;
            }
        }
    }
}