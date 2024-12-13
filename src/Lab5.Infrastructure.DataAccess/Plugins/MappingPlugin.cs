using Itmo.Dev.Platform.Postgres.Plugins;
using Models.Operations;
using Models.Users;
using Npgsql;

namespace Infrastructure.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder.MapEnum<UserRole>("user_role");
        builder.MapEnum<OperationType>("operation_type");
        builder.MapEnum<OperationResult>("operation_result");
    }
}