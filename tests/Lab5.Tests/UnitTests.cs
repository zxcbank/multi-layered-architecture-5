using Contracts.Users;
using Lab5.Application.Users;
using Models.Users;
using Xunit;

namespace Lab5.Tests;

public class UnitTests
{
    [Fact]
    public void WithDraw100TestSuccess()
    {
        // Arrange
        var userManager = new CurrentUserManager();
        var user = new User(1, 123, UserRole.User, 300);
        userManager.User = user;

        // Act
        userManager.Withdraw(100);

        // Assert
        Assert.Equal(200, userManager.User?.MoneyAmount);
    }

    [Fact]
    public void AddFund100TestSuccess()
    {
        // Arrange
        var user = new User(1, 123, UserRole.User, 200);
        var userManager = new CurrentUserManager();
        userManager.User = user;

        // Act
        userManager.AddFund(100);

        // Assert
        Assert.Equal(300, userManager.User?.MoneyAmount);
    }

    [Fact]
    public void WithDraw300TestFail()
    {
        // Arrange
        var userManager = new CurrentUserManager();
        var user = new User(1, 123, UserRole.User, 100);
        userManager.User = user;

        // Act
        Contracts.Users.WithDrawResult res = userManager.Withdraw(300);

        // Assert
        Assert.Equal(new WithDrawResult.InsufficientFunds(), res);
    }
}