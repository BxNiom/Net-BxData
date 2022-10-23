using System.Data.Common;

namespace Bx.Data;

public static partial class DbCommandEx
{
    public static int Insert<TPoco>(this DbCommand command, DbContext ctx, TPoco poco) where TPoco : class
    {
        var pocoInfo = ctx.GetPocoInfo<TPoco>();

        var columns = (from p in pocoInfo.Properties where p.IsPrimaryKey == false select p).ToList();

        if (!pocoInfo.PrimaryKey.IsAutoincrement)
            columns.Add(pocoInfo.PrimaryKey);

        var query = ctx.Dialect.InsertQuery
            .Replace("{table}", pocoInfo.TableName)
            .Replace("{columns}", columns.Aggregate("", (src, p) => src + $"{p.ColumnParameter.column}, ")[..^2])
            .Replace("{values}", columns.Aggregate("", (src, p) => src + $"{p.ColumnParameter.parameter}, ")[..^2]);

        if (ctx.Dialect.InsertReturn)
            query = query.Replace("{return}", pocoInfo.PrimaryKey.ColumnName);

        command.CommandText = query;
        command.CreateParameters(ctx, columns, pocoInfo, poco);

        if (!ctx.Dialect.InsertReturn)
        {
            if (command.ExecuteNonQuery() > 0)
                command.CommandText = ctx.Dialect.LastIdQuery;
            else
                return 0;
        }

        var pk = command.ExecuteScalar();
        if (pk != null)
            pocoInfo.PrimaryKey.Property.SetValue(poco, pk);

        return pk == null ? 0 : 1;
    }

    public static async Task<int> InsertAsync<TPoco>(this DbCommand command, DbContext ctx, TPoco poco,
        CancellationToken cancellationToken = default) where TPoco : class
    {
        var pocoInfo = ctx.GetPocoInfo<TPoco>();
        var columns = (from p in pocoInfo.Properties where p.IsPrimaryKey == false select p).ToList();

        if (!pocoInfo.PrimaryKey.IsAutoincrement)
            columns.Add(pocoInfo.PrimaryKey);

        var query = ctx.Dialect.InsertQuery
            .Replace("{table}", pocoInfo.TableName)
            .Replace("{columns}", columns.Aggregate("", (src, p) => src + $"{p.ColumnParameter.column}, ")[..^2])
            .Replace("{values}", columns.Aggregate("", (src, p) => src + $"{p.ColumnParameter.parameter}, ")[..^2]);

        if (ctx.Dialect.InsertReturn)
            query = query.Replace("{return}", pocoInfo.PrimaryKey.ColumnName);

        command.CommandText = query;
        command.CreateParameters(ctx, columns, pocoInfo, poco);

        if (!ctx.Dialect.InsertReturn)
        {
            if (await command.ExecuteNonQueryAsync(cancellationToken) > 0)
                command.CommandText = ctx.Dialect.LastIdQuery.Replace("{table}", pocoInfo.TableName);
            else
                return 0;
        }

        var pk = await command.ExecuteScalarAsync(cancellationToken);
        if (pk != null)
            pocoInfo.PrimaryKey.Property.SetValue(poco, pk);

        return pk == null ? 0 : 1;
    }
}