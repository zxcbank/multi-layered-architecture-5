using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.OutputRun;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.ParameterHandlers.ConcreteHandlers;
using Xunit;

namespace Lab4.Tests;

public class MainTests
{
    [Fact]
    public void VuildCommnadTest()
    {
        string command = "connect c:\\ -m local";
        var fs = new FileSystem("filesystem");

        IParameterHandler handler = new ConnectHandler()
            .AddNext(new DisconnectHandler()
                .AddNext(new FileCopyHandler()
                    .AddNext(new FileDeleteHandler()
                        .AddNext(new FileMoveHandler()
                            .AddNext(new FileRenameHandler()
                                .AddNext(new FileShowHandler()
                                    .AddNext(new TreeGotoHandler()
                                        .AddNext(new TreeListHandler()))))))));

        var runner = new OutputRunner(handler);
        runner.Run(command.Split(' '), fs);
        Assert.True(fs.Name == "filesystem" && fs.Mode == "local" && fs.Root == "c:\\" && fs.CurrentAdress == "c:\\");
    }
}