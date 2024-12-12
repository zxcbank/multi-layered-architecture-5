using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Infrastructure.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public bool ValidatePass(string currentPass)
    {
        const string sql = $"""
                            select *
                            from adminpass
                            where pass = :Pass;
                            """;

        // NpgsqlConnection connection = _connectionProvider
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
            .AddParameter("Pass", currentPass);

        using NpgsqlDataReader reader = command.ExecuteReader();

        return reader.Read();
    }
}