using Models.Operations;

namespace Abstractions.Repositories;

public interface IOperationsRepository
{
    IEnumerable<Operation> GetAllOperationsByAccountId(long userid);
}