using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public record ScheduleModule : IHasId
{
    public int Semester { get; private set; }

    public Subject Subj { get; private set; }

    public int Id { get; }

    public ScheduleModule(int semester, Subject subj)
    {
        Semester = semester;
        Subj = subj;
        Id = IdGenerator.GenericIdentity();
    }
}