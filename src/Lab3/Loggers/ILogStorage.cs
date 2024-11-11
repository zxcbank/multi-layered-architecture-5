namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public interface ILogStorage
{
    void Save(Message.Message message);
}