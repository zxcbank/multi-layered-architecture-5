using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.OutputRun;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers.ConnectHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers.DisConnectHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers.TreeHandlers;
using Xunit;

namespace Lab4.Tests;

public class MainTests
{
    [Fact]
    public void BuildCommnadTest()
    {
        string command = "connect C:\\Users\\Святослав\\Desktop\\habr\\ -m local";
        string command2 = "tree list -d 4";

        var fs = new LocalFileSystem("filesystem");

        IExternalHandler handler = new ConnectHandler()
            .AddNext(new DisconnectHandler()
                .AddNext(new TreeHandler()));

        var runner = new OutputRunner(handler);
        runner.Run(command.Split(" "), fs);
        runner.Run(command2.Split(" "), fs);
        Assert.True(fs.Name == "filesystem" && fs.Mode == "local" && fs.Root == "c:\\" && fs.CurrentAdress == "c:\\");
    }
}