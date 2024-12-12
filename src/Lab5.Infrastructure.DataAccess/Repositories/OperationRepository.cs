using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Operations;
using Npgsql;

namespace Infrastructure.Repositories;

public class OperationRepository : IOperationsRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public OperationRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<Operation> GetAllOperationsByAccountId(long userid)
    {
        const string sql = $"""
                            select *
                            from operations
                            where user_id = :UserId;
                            """;

        // var connection = _connectionProvider
        //     .GetConnectionAsync(default)
        //     .GetAwaiter()
        //     .GetResult();
        ValueTask<NpgsqlConnection> connectionTask = _connectionProvider.GetConnectionAsync(default);

        NpgsqlConnection connection;

        if (connectionTask.IsCompleted)
        {
            connection = connectionTask.Result;
        }
        else
        {
            connection = connectionTask.AsTask().GetAwaiter().GetResult();
        }

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("UserId", userid);
        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new Operation(
                reader.GetInt64(0),
                reader.GetInt64(1),
                reader.GetFieldValue<OperationType>(2),
                reader.GetDecimal(3),
                reader.GetFieldValue<OperationResult>(4));
        }
    }

    public long? InsertOperation(long userid, OperationType type, decimal amount, OperationResult result)
    {
        const string sql = $"""
                            insert into operations (user_id, operation_type, money_amount, operation_result)
                            VALUES (userid, type, amount, result)
                            RETURNING operation_id 
                            """;

        ValueTask<NpgsqlConnection> connectionTask = _connectionProvider.GetConnectionAsync(default);

        NpgsqlConnection connection;

        if (connectionTask.IsCompleted)
        {
            connection = connectionTask.Result;
        }
        else
        {
            connection = connectionTask.AsTask().GetAwaiter().GetResult();
        }

        using var command = new NpgsqlCommand(sql, connection);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return reader.GetInt64(0);
    }
}