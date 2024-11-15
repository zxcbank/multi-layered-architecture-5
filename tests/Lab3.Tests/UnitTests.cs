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
        Func<Priority, bool> filter = priority => priority.Value == "high priority";

        var user = new User(new User.Attributes(100, 90, 80));

        var userAddres = new UserAddress(user);

        var proxy = new FilterProxy(filter, userAddres);

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
        Func<Priority, bool> filter = priority => priority.Value == "high priority";

        var user = new User(new User.Attributes(100, 90, 80));

        var userAddres = new UserAddress(user);

        var proxy = new FilterProxy(filter, userAddres);

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
        Func<Priority, bool> filter = priority => priority.Value == "high priority";

        var user = new User(new User.Attributes(100, 90, 80));

        var userAddres = new UserAddress(user);

        var proxy = new FilterProxy(filter, userAddres);

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
        Func<Priority, bool> filter = priority => priority.Value == "high priority";

        var userAddressMock = new Mock<IAddressee>();

        var proxy = new FilterProxy(filter, userAddressMock.Object);

        var userlog = new UserLogStorage();

        var logdec = new LoggerDecorator(proxy, userlog);

        var message = new Message(
            new Priority("low priority"),
            "body",
            "header");

        // Act
        logdec.SendMessage(message);

        // Assert
        userAddressMock.Verify(r => r.SendMessage(message), Times.Never);
    }

    [Fact]
    public void LogCheckValidMessage()
    {
        // Arrange
        Func<Priority, bool> filter = priority => priority.Value == "high priority";

        var user = new User(new User.Attributes(100, 90, 80));

        var userAddres = new UserAddress(user);

        var proxy = new FilterProxy(filter, userAddres);

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
        Func<Priority, bool> filter = priority => priority.Value == "high priority";

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
        Func<Priority, bool> filter = priority => priority.Value == "high priority";

        Func<Priority, bool> filter2 = priority => priority.Value == "low priority";

        var user = new User(new User.Attributes(100, 90, 80));

        var userAdress1 = new UserAddress(user);

        var proxy = new FilterProxy(filter, userAdress1);

        var proxy2 = new FilterProxy(filter2, userAdress1);

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
        Assert.True(user.Messages.Count == 1);
    }
}