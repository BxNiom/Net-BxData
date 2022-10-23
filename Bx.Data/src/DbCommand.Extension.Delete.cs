using System.Data.Common;

namespace Bx.Data;

public static partial class DbCommandEx
{
    public static int Delete<TPoco>(this DbCommand command, DbContext ctx, TPoco poco) where TPoco : class
    {
        var pocoInfo = ctx.GetPocoInfo<TPoco>();

        var pk = pocoInfo.PrimaryKey.ColumnParameter;

        var query = ctx.Dialect.DeleteQuery
            .Replace("{table}", pocoInfo.TableName)
            .Replace("{where}", $"{pk.column} = {pk.parameter}");

        Console.WriteLine(query);

        command.CommandText = query;
        command.CreateParameters(ctx, pocoInfo.PrimaryKey, pocoInfo, poco);

        return command.ExecuteNonQuery();
    }

    public static async Task<int> DeleteAsync<TPoco>(this DbCommand command, DbContext ctx, TPoco poco,
        CancellationToken cancellationToken = default) where TPoco : class
    {
        var pocoInfo = ctx.GetPocoInfo<TPoco>();

        var pk = pocoInfo.PrimaryKey.ColumnParameter;

        var query = ctx.Dialect.DeleteQuery
            .Replace("{table}", pocoInfo.TableName)
            .Replace("{where}", $"{pk.column} = {pk.parameter}");

        command.CommandText = query;
        command.CreateParameters(ctx, pocoInfo.PrimaryKey, pocoInfo, poco);

        return await command.ExecuteNonQueryAsync(cancellationToken);
    }
}