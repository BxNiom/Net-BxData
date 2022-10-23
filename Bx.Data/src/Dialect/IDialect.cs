using System.Data;
using System.Data.Common;
using Bx.Data.Query;

namespace Bx.Data.Dialect;

/// <summary>
///     Interface for SQL dialects
/// </summary>
public interface IDialect
{
    /// <summary>
    ///     If true the last inserted ID is returned by insert
    /// </summary>
    bool InsertReturn { get; }

    /// <summary>
    ///     Simple SQL Query for INSERT
    ///     Template variables:
    ///     {table} - table name
    ///     {columns} - column names
    ///     {values} - values
    ///     {return} - return column if <see cref="InsertReturn" /> is true
    /// </summary>
    string InsertQuery { get; }

    /// <summary>
    ///     Simple SQL Query for DELETE
    ///     Template variables:
    ///     {table} - table name
    ///     {where} - where clauses
    /// </summary>
    string DeleteQuery { get; }

    /// <summary>
    ///     Simple SQL Query for UPDATE
    ///     Template variables:
    ///     {table} - table name
    ///     {set} - set values
    ///     {where} - where clauses
    /// </summary>
    string UpdateQuery { get; }

    /// <summary>
    ///     Simple SQL Query for SELECT
    ///     Template variables:
    ///     {table} - table name
    ///     {columns} - column names
    /// </summary>
    string SelectQuery { get; }

    string LastIdQuery { get; }
    ICompiler? QueryCompiler { get; }
    DbConnection CreateConnection();
    object CreateParameter(string name, object? value);
    object? GetValue(DbDataReader reader, int ordinal, DbType dataType);
}