using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Infrastructure.Migations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create type user_role as enum
    (
        'Admin', 
        'user'
    );
    
    create type operation_type as enum
    (
        'WithdrawFunds', 
        'AddFunds',
    );
    
    create type operation_result as enum
    (
        'Success', 
        'Fail',
    );

    create table users
    (
        user_id bigint primary key generated always as identity ,
        pin int not null ,
        user_role user_role not null,
        money_amount int not null 
    );

    create table operations
    (
        operation_id bigint primary key generated always as identity ,
        user_id bigint not null,
        operation_type operation_type not null,
        money_amount int not null,
        operation_result operation_result not null
    );
    
    create table adminpass
    (
        pass bigint primary key bigint not null 
    );
    
    INSERT INTO adminpass (pass) VALUES (mama);
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        $"""
         drop table users;
         drop table operations;

         drop type user_role;
         drop type operation_type;
         drop type operation_result;
         """;
}