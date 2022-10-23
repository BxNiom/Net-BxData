using System.Data.Common;

namespace Bx.Data;

public static class DbDataReaderEx
{
    public static TPoco ReadPoco<TPoco>(this DbDataReader reader, DbContext ctx) where TPoco : class
    {
        var pocoInfo = ctx.GetPocoInfo<TPoco>();
        var poco = (TPoco)pocoInfo.PocoConstructor.Invoke(Array.Empty<object?>());

        foreach (var pocoProperty in pocoInfo.Properties)
        {
            var ordinal = reader.GetOrdinal(pocoProperty.ColumnName);
            if (reader.IsDBNull(ordinal)) continue;
            pocoProperty.Property.SetValue(poco, ctx.Dialect.GetValue(reader, ordinal, pocoProperty.DataType));
        }

        return poco;
    }

    public static IEnumerable<TPoco?> Pocos<TPoco>(this DbDataReader reader, DbContext ctx) where TPoco : class
    {
        while (reader.Read())
            yield return reader.ReadPoco<TPoco>(ctx);

        yield return default;
    }

    public static async IAsyncEnumerable<TPoco?> PocosAsync<TPoco>(this DbDataReader reader, DbContext ctx)
        where TPoco : class
    {
        while (await reader.ReadAsync()) yield return reader.ReadPoco<TPoco>(ctx);

        yield return default;
    }
}