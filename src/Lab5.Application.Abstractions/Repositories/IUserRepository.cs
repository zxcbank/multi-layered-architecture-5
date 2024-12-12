using Models.Users;

namespace Abstractions.Repositories;

public interface IUserRepository
{
    User? FindByUserAccountId(long userid);

    long? InsertNewUser(long pin, UserRole role);

    void ChangeBalance(decimal sum, User user);
}