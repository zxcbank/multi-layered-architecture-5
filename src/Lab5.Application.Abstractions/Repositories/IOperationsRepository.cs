using Models.Operations;

namespace Abstractions.Repositories;

public interface IOperationsRepository
{
    IEnumerable<Operation> GetAllOperationsByAccountId(long userid);

    long? InsertOperation(long userid, OperationType type, decimal amount, OperationResult result);
}