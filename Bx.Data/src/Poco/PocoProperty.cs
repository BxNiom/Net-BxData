using System.Data;
using System.Reflection;

namespace Bx.Data.Poco;

public readonly struct PocoProperty
{
    public PropertyInfo Property { get; }
    public string ColumnName { get; }
    public string PropertyName => Property.Name;
    public Type PropertyType => Property.PropertyType;
    public DbType DataType { get; }
    public bool IsPrimaryKey { get; }
    public bool IsAutoincrement { get; }

    public (string column, string parameter) ColumnParameter { get; }

    internal PocoProperty(PropertyInfo property, string columnName, DbType dataType, bool isPrimaryKey,
        bool isAutoincrement)
    {
        Property = property;
        ColumnName = columnName;
        DataType = dataType;
        IsPrimaryKey = isPrimaryKey;
        IsAutoincrement = isAutoincrement;
        ColumnParameter = (columnName, $"PARAM_{columnName.ToUpper()}");
    }

    public object? GetValue(object poco)
    {
        return Property.GetValue(poco);
    }

    public T? GetValue<T>(object poco)
    {
        try
        {
            return (T)GetValue(poco);
        }
        catch
        {
            return default;
        }
    }

    public void SetValue(object poco, object? value)
    {
        Property.SetValue(poco, value);
    }
}