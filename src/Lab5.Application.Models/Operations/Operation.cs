namespace Models.Operations;

public record Operation(long OperationId, long AccountId, OperationType Type, decimal MoneyAmount, OperationResult Result);