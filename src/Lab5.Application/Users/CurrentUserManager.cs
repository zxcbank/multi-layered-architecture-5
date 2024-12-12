using Contracts.Users;
using Models.Users;

namespace Lab5.Application.Users;

internal class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
}