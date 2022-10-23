using System.Data.Common;
using Bx.Data.Poco;

namespace Bx.Data;

public static partial class DbCommandEx
{
    internal static void CreateParameters<TPoco>(this DbCommand command, DbContext ctx,
        IEnumerable<PocoProperty> columnsParameters, PocoInfo pocoInfo, TPoco poco) where TPoco : class
    {
        foreach (var pc in columnsParameters)
            command.Parameters.Add(ctx.Dialect.CreateParameter(pc.ColumnParameter.parameter, pc.GetValue(poco)));
    }

    internal static void CreateParameters<TPoco>(this DbCommand command, DbContext ctx,
        PocoProperty prop, PocoInfo pocoInfo, TPoco poco) where TPoco : class
    {
        command.Parameters.Add(ctx.Dialect.CreateParameter(prop.ColumnParameter.parameter, prop.GetValue(poco)));
    }
}