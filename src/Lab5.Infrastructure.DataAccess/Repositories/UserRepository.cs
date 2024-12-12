﻿using Abstractions.Repositories;
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
                            where user_id = :userid;
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
            .AddParameter("user_id", userid);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new User(
            reader.GetInt64(0),
            reader.GetInt64(1),
            reader.GetFieldValue<UserRole>(2),
            reader.GetDecimal(3));
    }
}