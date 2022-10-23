using System.Data.Common;

namespace Bx.Data;

public static class DbContextEx
{
    public static int Insert<TPoco>(this DbContext ctx, TPoco poco, DbConnection? connection = null) where TPoco : class
    {
        return ctx.Execute(connection, true, conn =>
        {
            using var cmd = conn.CreateCommand();
            return cmd.Insert(ctx, poco);
        });
    }

    public static async Task<int> InsertAsync<TPoco>(this DbContext ctx, TPoco poco, DbConnection? connection = null,
        CancellationToken cancellationToken = default)
        where TPoco : class
    {
        return await ctx.ExecuteAsync(connection, true, async (conn, cToken) =>
        {
            await using var cmd = conn.CreateCommand();
            return await cmd.InsertAsync(ctx, poco, cToken);
        }, cancellationToken);
    }

    public static int Update<TPoco>(this DbContext ctx, TPoco poco, DbConnection? connection = null) where TPoco : class
    {
        return ctx.Execute(connection, true, conn =>
        {
            using var cmd = conn.CreateCommand();
            return cmd.Update(ctx, poco);
        });
    }

    public static async Task<int> UpdateAsync<TPoco>(this DbContext ctx, TPoco poco, DbConnection? connection = null,
        CancellationToken cancellationToken = default)
        where TPoco : class
    {
        return await ctx.ExecuteAsync(connection, true, async (conn, cToken) =>
        {
            await using var cmd = conn.CreateCommand();
            return await cmd.UpdateAsync(ctx, poco, cToken);
        }, cancellationToken);
    }

    public static int Delete<TPoco>(this DbContext ctx, TPoco poco, DbConnection? connection = null) where TPoco : class
    {
        return ctx.Execute(connection, true, conn =>
        {
            using var cmd = conn.CreateCommand();
            return cmd.Delete(ctx, poco);
        });
    }

    public static async Task<int> DeleteAsync<TPoco>(this DbContext ctx, TPoco poco, DbConnection? connection = null,
        CancellationToken cancellationToken = default)
        where TPoco : class
    {
        return await ctx.ExecuteAsync(connection, true, async (conn, cToken) =>
        {
            await using var cmd = conn.CreateCommand();
            return await cmd.DeleteAsync(ctx, poco, cToken);
        }, cancellationToken);
    }

    public static DbDataReader Select<TPoco>(this DbContext ctx, DbConnection? connection = null) where TPoco : class
    {
        return ctx.Execute(connection, false, conn =>
        {
            using var cmd = conn.CreateCommand();
            return cmd.Select<TPoco>(ctx);
        });
    }

    public static async Task<DbDataReader> SelectAsync<TPoco>(this DbContext ctx, DbConnection? connection = null,
        CancellationToken cancellationToken = default) where TPoco : class
    {
        return await ctx.ExecuteAsync(connection, true, async (conn, cToken) =>
        {
            await using var cmd = conn.CreateCommand();
            return await cmd.SelectAsync<TPoco>(ctx, cToken);
        }, cancellationToken);
    }
}