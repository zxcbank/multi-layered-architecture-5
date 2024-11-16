using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;
using Itmo.ObjectOrientedProgramming.Lab2.Factories;
using Itmo.ObjectOrientedProgramming.Lab2.Results;
using Xunit;

namespace Lab2.Tests;

public class TestModule
{
    [Fact]
    public void LabworkFactory_ShouldConstructLabwork()
    {
        // Arrange
        var idGeneratorUser = new IdGenerator();
        var idGeneratorLabwork = new IdGenerator();
        var user = new User("some name", idGeneratorUser);

        var factory = new LabworkBuilderFactory(user);

        // Act
        Labwork lab1 = factory.Create()
            .AddName("some name")
            .AddAuthor(user)
            .AddCriteria("some criteria")
            .AddDescription("some decription")
            .AddPoints(24)
            .Build(idGeneratorLabwork);

        // Assert
        Assert.IsType<Labwork>(lab1);
    }

    [Fact]
    public void ChangeName_ReturnsWrongAuthor_NotAuthorChange()
    {
        // Arrange
        var idGeneratorUser = new IdGenerator();
        var idGeneratorLabwork = new IdGenerator();
        var main_user = new User("name1", idGeneratorUser);
        var other_user = new User("name2", idGeneratorUser);
        string labname = "labname1";

        var factory = new LabworkBuilderFactory(main_user);

        // Act
        Labwork lab1 = factory.Create()
            .AddName("some name")
            .AddAuthor(main_user)
            .AddCriteria("some criteria")
            .AddDescription("some description")
            .AddPoints(24)
            .Build(idGeneratorLabwork);

        // Assert
        Assert.IsType<ChangeLabworkResult.WrongAuthor>(lab1.ChangeName(other_user, labname));
    }

    [Fact]
    public void BuildLabworkBasedOnOtherLabwork_OnValidLabwork()
    {
        // Arrange
        var idGeneratorUser = new IdGenerator();
        var idGeneratorLabwork = new IdGenerator();
        var main_user = new User("some name", idGeneratorUser);

        var factory = new LabworkBuilderFactory(main_user);

        Labwork lab1 = factory.Create()
            .AddName("some name")
            .AddAuthor(main_user)
            .AddCriteria("some criteria")
            .AddDescription("some description")
            .AddPoints(24)
            .Build(idGeneratorLabwork);

        // Act
        Labwork lab2 = factory.Create()
            .AddBaseLabwork(lab1, idGeneratorLabwork);

        // Assert
        Assert.IsType<Labwork>(lab2);
    }

    [Fact]
    public void CreateValidSubject()
    {
        // Arrange
        var idGeneratorUser = new IdGenerator();
        var idGeneratorLabwork = new IdGenerator();
        var idGeneratorLecture = new IdGenerator();
        var idGeneratorSubject = new IdGenerator();
        var main_user = new User("some name", idGeneratorUser);

        var factory = new LabworkBuilderFactory(main_user);

        Labwork lab1 = factory.Create()
            .AddName("some name")
            .AddAuthor(main_user)
            .AddCriteria("some criteria")
            .AddDescription("some description")
            .AddPoints(20)
            .Build(idGeneratorLabwork);
        var labs = new Dictionary<long, Labwork>();
        labs[lab1.Id] = lab1;
        labs[lab1.Id] = factory.Create()
            .AddBaseLabwork(lab1, idGeneratorLabwork);
        labs[lab1.Id] = factory.Create()
            .AddBaseLabwork(lab1, idGeneratorLabwork);
        labs[lab1.Id] = factory.Create()
            .AddBaseLabwork(lab1, idGeneratorLabwork);

        var factory2 = new LectureBuilderFactory(main_user);

        Lecture lec1 = factory2.Create()
            .AddName("some name")
            .AddAuthor(main_user)
            .AddCriteria("some criteria")
            .AddDescription("some description")
            .Build(idGeneratorLecture);
        var lecs = new Dictionary<long, Lecture>();

        lecs[lec1.Id] = lec1;

        var ps_sb_Factory = new SubjectBuilderFactory(main_user);

        // Act
        CreateSubjectResult some_subject = ps_sb_Factory.Create()
            .AddName("some name")
            .AddLabworks(new Dictionary<long, Labwork>(labs))
            .AddLectures(new Dictionary<long, Lecture>(lecs))
            .AddSubjectType(new Exam(20))
            .Build(idGeneratorSubject);

        // Assert
        Assert.IsType<CreateSubjectResult.Success>(some_subject);
    }
}