    namespace Itmo.ObjectOrientedProgramming.Lab2;

    public class Lecture : IHasId
    {
        public static LecturesBuilder Lecturekbuilder => new LecturesBuilder();

        public Guid Id { get; private set; }

        public Guid? BaseID { get; private set; }

        public string Name { get; private set; }

        public string Criteria { get; private set; }

        public string Description { get; private set; }

        private IUser Author { get; }

        public Lecture(
            Guid? baseid,
            string name,
            IUser author,
            string criteria,
            string description)
        {
            Name = name;
            BaseID = baseid;
            Description = description;
            Criteria = criteria;
            Author = author;
            Id = Guid.NewGuid();
        }

        public ChangeLectureResult Change(
            IUser user,
            string name,
            string criteria,
            string description,
            Guid baseid)
        {
            if (!user.Equals(Author))
            {
                return new ChangeLectureResult.WrongAuthor();
            }
            else
            {
                Name = name;
                Criteria = criteria;
                Description = description;
                BaseID = baseid;
            }

            return new ChangeLectureResult.Success();
        }

        public class LecturesBuilder
        {
            private Guid? _baseId;

            private string? _name;

            private IUser? _author;

            private string? _criteria;

            private string? _description;

            public LecturesBuilder()
            {
                _baseId = null;
                _name = null;
                _author = null;
                _criteria = null;
                _description = null;
            }

            public LecturesBuilder AddBaseId(Guid id)
            {
                _baseId = id;
                return this;
            }

            public LecturesBuilder AddName(string name)
            {
                _name = name;
                return this;
            }

            public LecturesBuilder AddAuthor(IUser author)
            {
                _author = author;
                return this;
            }

            public LecturesBuilder AddCriteria(string criteria)
            {
                _criteria = criteria;
                return this;
            }

            public LecturesBuilder AddDescription(string description)
            {
                _description = description;
                return this;
            }

            public Lecture Build()
            {
                return new Lecture(
                    _baseId,
                    _name ?? throw new InvalidOperationException(),
                    _author ?? throw new InvalidOperationException(),
                    _criteria ?? throw new InvalidOperationException(),
                    _description ?? throw new InvalidOperationException());
            }
        }
    }