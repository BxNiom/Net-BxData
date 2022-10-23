using System.Data.Common;

namespace Bx.Data;

public static partial class DbCommandEx
{
    public static T? ExecuteScalar<T>(this DbCommand command)
    {
        var obj = command.ExecuteScalar();

        try
        {
            return (T?)Convert.ChangeType(obj, typeof(T));
        }
        catch (InvalidCastException)
        {
            return default;
        }
    }

    public static async Task<T?> ExecuteScalarAsync<T>(this DbCommand command,
        CancellationToken cancellationToken = default)
    {
        var obj = await command.ExecuteScalarAsync(cancellationToken);

        try
        {
            return (T?)Convert.ChangeType(obj, typeof(T));
        }
        catch (InvalidCastException)
        {
            return default;
        }
    }
}