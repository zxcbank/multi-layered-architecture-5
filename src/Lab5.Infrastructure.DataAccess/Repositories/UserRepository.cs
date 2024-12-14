using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Users;
using Npgsql;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public User? FindByUserAccountId(long userid)
    {
        const string sql = $"""
                            select *
                            from users
                            where user_id = :UserId;
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

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("UserId", userid);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new User(
            reader.GetInt64(0),
            reader.GetInt64(1),
            reader.GetFieldValue<UserRole>(2),
            reader.GetDecimal(3));
    }

    public long? InsertNewUser(long pin, UserRole role)
    {
        const string sql = $"""
                            insert into users (pin, user_role, money_amount)
                            VALUES (:userpin, :role, 0)
                            RETURNING user_id 
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

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("userpin", pin)
            .AddParameter("role", role)
            .AddParameter("money_amount", 0);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return reader.GetInt64(0);
    }

    public long? ChangeBalance(decimal sum, long userid)
    {
        const string sql = $""""
                            UPDATE users
                            SET money_amount = money_amount + :sum
                            WHERE user_id = :UserId;

                            """";

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
            .AddParameter("UserId", userid)
            .AddParameter("sum", sum);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return reader.GetInt64(0);
    }
}