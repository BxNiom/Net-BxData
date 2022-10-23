using System.Data;
using System.Data.Common;
using Bx.Data.Query;

namespace Bx.Data.Dialect;

public abstract class AbstractDialect : IDialect
{
    public abstract bool InsertReturn { get; }
    public abstract string LastIdQuery { get; }
    public virtual string InsertQuery => "INSERT INTO {table}({columns}) VALUES({values});";
    public virtual string DeleteQuery => "DELETE FROM {table} WHERE {where};";
    public virtual string UpdateQuery => "UPDATE {table} SET {set} WHERE {where};";
    public virtual string SelectQuery => "SELECT {columns} FROM {table};";
    public virtual ICompiler? QueryCompiler => null;

    public abstract DbConnection CreateConnection();

    public abstract object CreateParameter(string name, object? value);

    public virtual object? GetValue(DbDataReader reader, int ordinal, DbType dataType)
    {
        return dataType switch
        {
            DbType.AnsiString => reader.GetString(ordinal),
            DbType.Binary => null,
            DbType.Byte => reader.GetByte(ordinal),
            DbType.Boolean => reader.GetBoolean(ordinal),
            DbType.Currency => reader.GetInt32(ordinal),
            DbType.Date => reader.GetDateTime(ordinal),
            DbType.DateTime => reader.GetDateTime(ordinal),
            DbType.Decimal => reader.GetDecimal(ordinal),
            DbType.Double => reader.GetDouble(ordinal),
            DbType.Guid => reader.GetGuid(ordinal),
            DbType.Int16 => reader.GetInt16(ordinal),
            DbType.Int32 => reader.GetInt32(ordinal),
            DbType.Int64 => reader.GetInt64(ordinal),
            DbType.Object => reader.GetValue(ordinal),
            DbType.SByte => Convert.ToSByte(reader.GetByte(ordinal)),
            DbType.Single => reader.GetFloat(ordinal),
            DbType.String => reader.GetString(ordinal),
            DbType.Time => reader.GetDateTime(ordinal),
            DbType.UInt16 => Convert.ToUInt16(reader.GetInt16(ordinal)),
            DbType.UInt32 => Convert.ToUInt32(reader.GetInt32(ordinal)),
            DbType.UInt64 => Convert.ToUInt64(reader.GetInt64(ordinal)),
            DbType.VarNumeric => reader.GetInt64(ordinal),
            DbType.AnsiStringFixedLength => reader.GetString(ordinal),
            DbType.StringFixedLength => reader.GetString(ordinal),
            DbType.Xml => reader.GetString(ordinal),
            DbType.DateTime2 => reader.GetDateTime(ordinal),
            DbType.DateTimeOffset => reader.GetDateTime(ordinal),
            _ => throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null)
        };
    }
}