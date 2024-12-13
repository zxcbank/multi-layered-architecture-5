using Abstractions.Repositories;
using Contracts.Users;
using Lab5.Application.Users;
using Models.Users;
using NSubstitute;
using Xunit;

namespace Lab5.Tests;

public class UnitTests
{
    [Fact]
    public void WithDraw300Success()
    {
        // Arrange
        IUserRepository userRepository = Substitute.For<IUserRepository>();
        IOperationsRepository operationsRepository = Substitute.For<IOperationsRepository>();
        IAdminRepository adminsRepository = Substitute.For<IAdminRepository>();
        var userManager = new CurrentUserManager();

        var userService = new UserService(userRepository, userManager, operationsRepository, adminsRepository);

        var user = new User(1, 123, UserRole.User, 1000);
        userManager.User = user;

        // Act
        userService.Withdraw(300);

        // Assert
        Assert.Equal(700, userManager.User?.MoneyAmount);
    }

    [Fact]
    public void AddFund300Success()
    {
        // Arrange
        IUserRepository userRepository = Substitute.For<IUserRepository>();
        IOperationsRepository operationsRepository = Substitute.For<IOperationsRepository>();
        IAdminRepository adminsRepository = Substitute.For<IAdminRepository>();
        var userManager = new CurrentUserManager();

        var userService = new UserService(userRepository, userManager, operationsRepository, adminsRepository);

        var user = new User(1, 123, UserRole.User, 0);
        userManager.User = user;

        // Act
        userService.AddFudns(300);

        // Assert
        Assert.Equal(300, userManager.User?.MoneyAmount);
    }

    [Fact]
    public void WithDraw300Fail()
    {
        // Arrange
        IUserRepository userRepository = Substitute.For<IUserRepository>();
        IOperationsRepository operationsRepository = Substitute.For<IOperationsRepository>();
        IAdminRepository adminsRepository = Substitute.For<IAdminRepository>();
        var userManager = new CurrentUserManager();

        var userService = new UserService(userRepository, userManager, operationsRepository, adminsRepository);

        var user = new User(1, 123, UserRole.User, 0);
        userManager.User = user;

        // Act
        WithDrawResult res = userService.Withdraw(300);

        // Assert
        Assert.Equal(new WithDrawResult.InsufficientFunds(), res);
    }
}