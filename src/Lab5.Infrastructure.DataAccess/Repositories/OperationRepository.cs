using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
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
                           where user_id = :userid;
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

        using var command = new NpgsqlCommand(sql, connection);
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
}