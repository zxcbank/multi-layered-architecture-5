using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.MessageLogic;
using Itmo.ObjectOrientedProgramming.Lab3.UserLogic;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class UnitTests
{
    [Fact]
    public void UserGetMessage()
    {
        // Arrange
        Func<int, bool> filter = priority => priority == 3;

        var user = new User();

        var userAddres = new UserAddress(user);

        var proxy = new FilterProxy(filter, userAddres);

        var userlog = new Logger();

        var logdec = new LoggerDecorator(proxy, userlog);

        var message = new Message(
            3,
            "body",
            "header");

        // Act
        logdec.ReceiveMessage(message);

        // Assert
        Assert.False(user.Messages[0].Read);
    }

    [Fact]
    public void ReadUnreadMessage()
    {
        // Arrange
        Func<int, bool> filter = priority => priority == 3;

        var user = new User();

        var userAddres = new UserAddress(user);

        var proxy = new FilterProxy(filter, userAddres);

        var userlog = new Logger();

        var logdec = new LoggerDecorator(proxy, userlog);

        var message = new Message(
            3,
            "body",
            "header");

        // Act
        logdec.ReceiveMessage(message);
        user.Messages[0].MarkMessage();

        // Assert
        Assert.True(user.Messages[0].Read);
    }

    [Fact]
    public void ReadReadMessage()
    {
        // Arrange
        Func<int, bool> filter = priority => priority == 3;

        var user = new User();

        var userAddres = new UserAddress(user);

        var proxy = new FilterProxy(filter, userAddres);

        var userlog = new Logger();

        var logdec = new LoggerDecorator(proxy, userlog);

        var message = new Message(
            3,
            "body",
            "header");

        // Act
        logdec.ReceiveMessage(message);
        user.Messages[0].MarkMessage();

        // Assert
        Assert.IsType<ReadMessageResult.AlreadyReadError>(user.Messages[0].MarkMessage());
    }

    [Fact]
    public void GetLowPriorityMessage()
    {
        // Arrange
        Func<int, bool> filter = priority => priority == 3;

        var userAddressMock = new Mock<IAddressee>();

        var proxy = new FilterProxy(filter, userAddressMock.Object);

        var userlog = new Logger();

        var logdec = new LoggerDecorator(proxy, userlog);

        var message = new Message(
            2,
            "body",
            "header");

        // Act
        logdec.ReceiveMessage(message);

        // Assert
        userAddressMock.Verify(r => r.ReceiveMessage(message), Times.Never);
    }

    [Fact]
    public void LogCheckValidMessage()
    {
        // Arrange
        Func<int, bool> filter = priority => priority == 3;

        var user = new User();

        var userAddres = new UserAddress(user);

        var proxy = new FilterProxy(filter, userAddres);

        var logmock = new Mock<ILogger>();

        var logdec = new LoggerDecorator(proxy, logmock.Object);

        var message = new Message(
            3,
            "body",
            "header");

        // Act
        logdec.ReceiveMessage(message);

        // Assert
        string logmessage =
            $"|Log| : Header: {message.Header} \n Body: {message.Body} \n Priority: {message.PriorityLevel}";
        logmock.Verify(logger => logger.Log(logmessage), Times.Once);
    }

    [Fact]
    public void MessangerRecievedValidMessage()
    {
        // Arrange
        Func<int, bool> filter = priority => priority == 3;

        var messangerMock = new Mock<IAddressee>();

        var proxy = new FilterProxy(filter, messangerMock.Object);

        var userlog = new Logger();

        var logdec = new LoggerDecorator(proxy, userlog);

        var message = new Message(
            3,
            "body",
            "header");

        // Act
        logdec.ReceiveMessage(message);

        // Assert
        messangerMock.Verify(r => r.ReceiveMessage(message), Times.Once);
    }

    [Fact]
    public void DoubleAdresseeRecievedValidMessageOnce()
    {
        // Arrange
        Func<int, bool> filter2 = priority => priority == 2;

        var user = new User();

        var userAdress1 = new UserAddress(user);

        var proxy2 = new FilterProxy(filter2, userAdress1);

        var group = new GroupAdress(new List<IAddressee> { userAdress1, proxy2 });

        var message = new Message(
            3,
            "body",
            "header");

        // Act
        group.ReceiveMessage(message);

        // Assert
        Assert.True(user.Messages.Count == 1);
    }
}