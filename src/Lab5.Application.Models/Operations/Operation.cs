namespace Models.Operations;

public record Operation(
    long OperationId,
    long AccountId,
    OperationType Type,
    decimal MoneyAmount,
    OperationResult Result)
{
    public override string ToString()
    {
        string message = Type switch
        {
            OperationType.AddFunds => $"AddFund",
            OperationType.WithdrawFunds => "Withdraw",
            _ => "WrongType",
        };

        string result_message = Result switch
        {
            OperationResult.Success => $"SUCCESS",
            OperationResult.Fail => "FAIL",
            _ => "WrongType",
        };
        return $"----------------\n " +
               $"Имя: {AccountId} \n " +
               $"Тип Операции: {message}\n" +
               $"{MoneyAmount} \n" +
               $"статус: {result_message}";
    }
}