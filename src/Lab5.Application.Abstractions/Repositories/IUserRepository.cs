using Models.Users;

namespace Abstractions.Repositories;

public interface IUserRepository
{
    User? FindByUserAccountId(long userid);
}