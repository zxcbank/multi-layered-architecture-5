namespace Abstractions.Repositories;

public interface IAdminRepository
{
    bool ValidatePass(string currentPass);
}