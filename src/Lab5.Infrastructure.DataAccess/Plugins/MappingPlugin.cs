﻿using Itmo.Dev.Platform.Postgres.Plugins;
using Models.Users;
using Npgsql;

namespace Infrastructure.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder.MapEnum<UserRole>();
    }
}