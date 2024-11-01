using Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;
using Itmo.ObjectOrientedProgramming.Lab2.Factories;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

// using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
// using Itmo.ObjectOrientedProgramming.Lab2.Results;
using Xunit;

namespace Lab2.Tests;

public class TestModule
{
    [Fact]
    public void Scenario1()
    {
        // Arrange
        var main_user = new User("P.Skakov");

        var skakov_LB_Factory = new LabworkFactory(main_user);

        // Act
        Labwork lab1 = skakov_LB_Factory.Create()
            .AddName("mp")
            .AddAuthor(main_user)
            .AddCriteria("no skat")
            .AddDescription("omp threads")
            .AddPoints(24)
            .Build();

        // Assert
        Assert.True(lab1 is Labwork);
    }

    [Fact]
    public void Scenario2()
    {
        // Arrange
        var main_user = new User("P.S.");
        var other_user = new User("s.zaimkin");
        string labname = "no labwork only skat";

        var skakov_LB_Factory = new LabworkFactory(main_user);

        // Act
        Labwork lab1 = skakov_LB_Factory.Create()
            .AddName("mp")
            .AddAuthor(main_user)
            .AddCriteria("no skat")
            .AddDescription("omp threads")
            .AddPoints(24)
            .Build();

        // Assert
        Assert.True(lab1.ChangeName(other_user, labname) is ChangeLabworkResult.WrongAuthor);
    }

    [Fact]
    public void Scenario3()
    {
        // Arrange
        var main_user = new User("P.S.");

        var skakov_LB_Factory = new LabworkFactory(main_user);

        Labwork lab1 = skakov_LB_Factory.Create()
            .AddName("mp")
            .AddAuthor(main_user)
            .AddCriteria("no skat")
            .AddDescription("omp threads")
            .AddPoints(24)
            .Build();

        // Act
        Labwork lab2 = skakov_LB_Factory.Create()
            .AddBaseLabwork(lab1);

        // Assert
        Assert.True(lab2 is Labwork);
    }

    [Fact]
    public void Scenario4()
    {
        // Arrange
        var main_user = new User("P.S.");

        // string name2 = "l2";
        var ps_LB_Factory = new LabworkFactory(main_user);

        Labwork lab1 = ps_LB_Factory.Create()
            .AddName("mp")
            .AddAuthor(main_user)
            .AddCriteria("no skat")
            .AddDescription("omp threads")
            .AddPoints(20)
            .Build();
        var labs = new List<Labwork>();
        labs.Add(lab1);
        labs.Add(ps_LB_Factory.Create()
            .AddBaseLabwork(lab1));
        labs.Add(ps_LB_Factory.Create()
            .AddBaseLabwork(lab1));
        labs.Add(ps_LB_Factory.Create()
            .AddBaseLabwork(lab1));

        var skakov_LecB_Factory = new LectureFactory(main_user);

        Lecture lec1 = skakov_LecB_Factory.Create()
            .AddName("l1")
            .AddAuthor(main_user)
            .AddCriteria("lec1")
            .AddDescription("omp threads")
            .Build();
        var lecs = new List<Lecture>();

        lecs.Add(lec1);

        var ps_sb_Factory = new SubjectFactory(main_user);
        Subject some_subject = ps_sb_Factory.Create()
            .AddName("maths")
            .AddLabworks(new ObjRepo<Labwork>(labs))
            .AddLectures(new ObjRepo<Lecture>(lecs))
            .AddSubjectType(new SubjectType.Exam(20))
            .Build();

        // Assert
        Assert.True(some_subject is Subject);
    }
}