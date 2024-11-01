namespace Itmo.ObjectOrientedProgramming.Lab2;

public class EducationalProgramm
{
    public static EducationalProgrammBuilder Builder => new EducationalProgrammBuilder();

    public IReadOnlyCollection<ObjRepo<Subject>> Subjects { get; set; }

    public string Name { get; private set; }

    public IUser User { get; private set; }

    public Guid Id { get; set; }

    private EducationalProgramm(
        string name,
        IReadOnlyCollection<ObjRepo<Subject>> subjects,
        IUser user)
    {
        Id = Guid.NewGuid();
        Subjects = subjects;
        User = user;
        Name = name;
    }

    public class EducationalProgrammBuilder
    {
        private IReadOnlyCollection<ObjRepo<Subject>>? _subjects;

        private string? _name;

        private IUser? _user;

        public EducationalProgrammBuilder() { }

        public EducationalProgrammBuilder AddSubjects(IReadOnlyCollection<ObjRepo<Subject>> subjects)
        {
            _subjects = subjects;
            return this;
        }

        public EducationalProgrammBuilder AddName(string name)
        {
            _name = name;
            return this;
        }

        public EducationalProgrammBuilder AddUser(IUser user)
        {
            _user = user;
            return this;
        }

        public EducationalProgramm Build()
        {
            return new EducationalProgramm(
                _name ?? throw new InvalidOperationException(),
                _subjects ?? throw new InvalidOperationException(),
                _user ?? throw new InvalidOperationException());
        }
    }
}