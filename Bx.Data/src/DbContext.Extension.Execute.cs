using System.Data;
using System.Data.Common;

namespace Bx.Data;

internal static class DbContextExecute
{
    public static TResult Execute<TResult>(this DbContext ctx, DbConnection? connection, bool doClose,
        Func<DbConnection, TResult> func)
    {
        var createConnection = connection == null;
        connection ??= ctx.CreateConnection();
        if (createConnection || !connection.State.HasFlag(ConnectionState.Open))
            connection.Open();

        var result = func(connection);

        if (doClose && createConnection)
        {
            connection.Close();
            connection.Dispose();
        }

        return result;
    }

    public static async Task<TResult> ExecuteAsync<TResult>(this DbContext ctx, DbConnection? connection, bool doClose,
        Func<DbConnection, CancellationToken, Task<TResult>> func, CancellationToken cancellationToken)
    {
        var createConnection = connection == null;
        connection ??= ctx.CreateConnection();
        if (createConnection || !connection.State.HasFlag(ConnectionState.Open))
            await connection.OpenAsync(cancellationToken);

        var result = await func(connection, cancellationToken);

        if (doClose && createConnection)
        {
            await connection.CloseAsync();
            await connection.DisposeAsync();
        }

        return result;
    }
}