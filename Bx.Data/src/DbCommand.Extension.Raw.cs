using System.Data.Common;

namespace Bx.Data;

public static partial class DbCommandEx
{
    public static int ExecuteNonQuery(this DbCommand command, string rawQuery)
    {
        command.CommandText = rawQuery;
        return command.ExecuteNonQuery();
    }

    public static DbDataReader ExecuteReader(this DbCommand command, string rawQuery)
    {
        command.CommandText = rawQuery;
        return command.ExecuteReader();
    }

    public static async Task<int> ExecuteNonQueryAsync(this DbCommand command, string rawQuery,
        CancellationToken cancellationToken = default)
    {
        command.CommandText = rawQuery;
        return await command.ExecuteNonQueryAsync(cancellationToken);
    }

    public static async Task<DbDataReader> ExecuteReaderAsync(this DbCommand command, string rawQuery,
        CancellationToken cancellationToken = default)
    {
        command.CommandText = rawQuery;
        return await command.ExecuteReaderAsync(cancellationToken);
    }
}