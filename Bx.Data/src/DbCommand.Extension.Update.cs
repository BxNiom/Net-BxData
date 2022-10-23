using System.Data.Common;

namespace Bx.Data;

public static partial class DbCommandEx
{
    public static int Update<TPoco>(this DbCommand command, DbContext ctx, TPoco poco) where TPoco : class
    {
        var pocoInfo = ctx.GetPocoInfo<TPoco>();

        var columns = (from p in pocoInfo.Properties where p.IsPrimaryKey == false select p).ToList();
        var pk = pocoInfo.PrimaryKey.ColumnParameter;

        var query = ctx.Dialect.UpdateQuery
            .Replace("{table}", pocoInfo.TableName)
            .Replace("{set}", columns.Aggregate("",
                (src, p) => src + $"{p.ColumnParameter.column} = {p.ColumnParameter.parameter}, ")[..^2])
            .Replace("{where}", $"{pk.column} = {pk.parameter}");

        command.CommandText = query;
        command.CreateParameters(ctx, columns, pocoInfo, poco);
        command.CreateParameters(ctx, new[] { pocoInfo.PrimaryKey }, pocoInfo, poco);

        return command.ExecuteNonQuery();
    }

    public static async Task<int> UpdateAsync<TPoco>(this DbCommand command, DbContext ctx, TPoco poco,
        CancellationToken cancellationToken = default) where TPoco : class
    {
        var pocoInfo = ctx.GetPocoInfo<TPoco>();

        var columns = (from p in pocoInfo.Properties where p.IsPrimaryKey == false select p).ToList();
        var pk = pocoInfo.PrimaryKey.ColumnParameter;

        var query = ctx.Dialect.UpdateQuery
            .Replace("{table}", pocoInfo.TableName)
            .Replace("{set}", columns.Aggregate("",
                (src, p) => src + $"{p.ColumnParameter.column} = {p.ColumnParameter.parameter}, ")[..^2])
            .Replace("{where}", $"{pk.column} = {pk.parameter}");

        command.CommandText = query;
        command.CreateParameters(ctx, columns, pocoInfo, poco);
        command.CreateParameters(ctx, new[] { pocoInfo.PrimaryKey }, pocoInfo, poco);

        return await command.ExecuteNonQueryAsync(cancellationToken);
    }
}