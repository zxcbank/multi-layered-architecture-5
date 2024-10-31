    namespace Itmo.ObjectOrientedProgramming.Lab2;

    public class Labwork
    {
        public static LabworkBuilder Labworkbuilder => new LabworkBuilder();

        public Guid Id { get; private set; }

        public Guid? BaseID { get; private set; }

        public string Name { get; private set; }

        public string Criteria { get; private set; }

        public string Description { get; private set; }

        public int Points { get; }

        private IUser Author { get; }

        public Labwork(
            Guid? baseid,
            string name,
            IUser author,
            string criteria,
            string description,
            int points)
        {
            Name = name;
            BaseID = baseid;
            Description = description;
            Criteria = criteria;
            Author = author;
            Points = points;
            Id = Guid.NewGuid();
        }

        public AddLabAuthorResult Change(IUser user, string name, string criteria, string description)
        {
            if (!user.Equals(Author))
            {
                return new AddLabAuthorResult.WrongAuthor();
            }
            else
            {
                Name = name;
                Criteria = criteria;
                Description = description;
            }

            return new AddLabAuthorResult.Success();
        }

        public class LabworkBuilder
        {
            private int? _points;

            private Guid? _baseId;

            private string? _name;

            private IUser? _author;

            private string? _criteria;

            private string? _description;

            public LabworkBuilder()
            {
                _baseId = null;
                _name = null;
                _author = null;
                _criteria = null;
                _description = null;
                _points = null;
            }

            public LabworkBuilder AddBaseId(Guid id)
            {
                _baseId = id;
                return this;
            }

            public LabworkBuilder AddName(string name)
            {
                _name = name;
                return this;
            }

            public LabworkBuilder AddAuthor(IUser author)
            {
                _author = author;
                return this;
            }

            public LabworkBuilder AddCriteria(string criteria)
            {
                _criteria = criteria;
                return this;
            }

            public LabworkBuilder AddDescription(string description)
            {
                _description = description;
                return this;
            }

            public LabworkBuilder AddPoints(int points)
            {
                _points = points;
                return this;
            }

            public Labwork Build()
            {
                return new Labwork(
                    _baseId,
                    _name ?? throw new InvalidOperationException(),
                    _author ?? throw new InvalidOperationException(),
                    _criteria ?? throw new InvalidOperationException(),
                    _description ?? throw new InvalidOperationException(),
                    _points ?? throw new InvalidOperationException());
            }
        }
    }