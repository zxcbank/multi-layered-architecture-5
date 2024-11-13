using Itmo.ObjectOrientedProgramming.Lab3.AddresseeDir;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;
using Itmo.ObjectOrientedProgramming.Lab3.UserDir;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class UnitTests
{
    [Fact]
    public void UserGetMessage()
    {
        // Arrange
        var filter = new Priority("high priority");

        var user = new User(new User.Attributes(100, 90, 80));

        var proxy = new FilterProxy(filter, user);

        var userlog = new UserLogStorage();

        var logdec = new LoggerDecorator(proxy, userlog);

        var message = new Message(
            new Priority("high priority"),
            "body",
            "header");

        // Act
        logdec.SendMessage(message);

        // Assert
        Assert.False(user.Messages[0].Read);
    }

    [Fact]
    public void ReadUnreadMessage()
    {
        // Arrange
        var filter = new Priority("high priority");

        var user = new User(new User.Attributes(100, 90, 80));

        var proxy = new FilterProxy(filter, user);

        var userlog = new UserLogStorage();

        var logdec = new LoggerDecorator(proxy, userlog);

        var message = new Message(
            new Priority("high priority"),
            "body",
            "header");

        // Act
        logdec.SendMessage(message);
        user.Messages[0].MarkMessage();

        // Assert
        Assert.True(user.Messages[0].Read);
    }

    [Fact]
    public void ReadReadMessage()
    {
        // Arrange
        var filter = new Priority("high priority");

        var user = new User(new User.Attributes(100, 90, 80));

        var proxy = new FilterProxy(filter, user);

        var userlog = new UserLogStorage();

        var logdec = new LoggerDecorator(proxy, userlog);

        var message = new Message(
            new Priority("high priority"),
            "body",
            "header");

        // Act
        logdec.SendMessage(message);
        user.Messages[0].MarkMessage();

        // Assert
        Assert.IsType<ReadMessageResult.AlreadyReadError>(user.Messages[0].MarkMessage());
    }

    [Fact]
    public void GetLowPriorityMessage()
    {
        // Arrange
        var filter = new Priority("high priority");

        var userMock = new Mock<IAddressee>();

        var proxy = new FilterProxy(filter, userMock.Object);

        var userlog = new UserLogStorage();

        var logdec = new LoggerDecorator(proxy, userlog);

        var message = new Message(
            new Priority("low priority"),
            "body",
            "header");

        // Act
        logdec.SendMessage(message);

        // Assert
        userMock.Verify(r => r.SendMessage(message), Times.Never);
    }

    [Fact]
    public void LogCheckValidMessage()
    {
        // Arrange
        var filter = new Priority("high priority");

        var user = new User(new User.Attributes(100, 90, 80));

        var proxy = new FilterProxy(filter, user);

        var logmock = new Mock<ILogger>();

        var logdec = new LoggerDecorator(proxy, logmock.Object);

        var message = new Message(
            new Priority("high priority"),
            "body",
            "header");

        // Act
        logdec.SendMessage(message);

        // Assert
        logmock.Verify(logger => logger.Log(message), Times.Once);
    }

    [Fact]
    public void MessangerRecievedValidMessage()
    {
        // Arrange
        var filter = new Priority("high priority");

        var messangerMock = new Mock<IAddressee>();

        var proxy = new FilterProxy(filter, messangerMock.Object);

        var userlog = new UserLogStorage();

        var logdec = new LoggerDecorator(proxy, userlog);

        var message = new Message(
            new Priority("high priority"),
            "body",
            "header");

        // Act
        logdec.SendMessage(message);

        // Assert
        messangerMock.Verify(r => r.SendMessage(message), Times.Once);
    }

    [Fact]
    public void DoubleAdresseeRecievedValidMessageOnce()
    {
        // Arrange
        var filter = new Priority("high priority");

        var filter2 = new Priority("low priority");

        var usermock = new Mock<IAddressee>();

        var proxy = new FilterProxy(filter, usermock.Object);

        var proxy2 = new FilterProxy(filter2, usermock.Object);

        var userlog = new UserLogStorage();

        var logdec = new LoggerDecorator(proxy, userlog);

        var logdec2 = new LoggerDecorator(proxy2, userlog);

        var message = new Message(
            new Priority("high priority"),
            "body",
            "header");

        // Act
        logdec.SendMessage(message);
        logdec2.SendMessage(message);

        // Assert
        usermock.Verify(r => r.SendMessage(message), Times.Once);
    }
}