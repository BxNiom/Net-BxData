using System.Data.Common;

namespace Bx.Data;

public static partial class DbCommandEx
{
    public static DbDataReader Select<TPoco>(this DbCommand command, DbContext ctx) where TPoco : class
    {
        var pocoInfo = ctx.GetPocoInfo<TPoco>();
        var query = ctx.Dialect.SelectQuery
            .Replace("{columns}", "*")
            .Replace("{table}", pocoInfo.TableName);

        command.CommandText = query;
        return command.ExecuteReader();
    }

    public static async Task<DbDataReader> SelectAsync<TPoco>(this DbCommand command, DbContext ctx,
        CancellationToken cancellationToken = default) where TPoco : class
    {
        var pocoInfo = ctx.GetPocoInfo<TPoco>();
        var query = ctx.Dialect.SelectQuery
            .Replace("{columns}", "*")
            .Replace("{table}", pocoInfo.TableName);

        command.CommandText = query;
        return await command.ExecuteReaderAsync(cancellationToken);
    }
}