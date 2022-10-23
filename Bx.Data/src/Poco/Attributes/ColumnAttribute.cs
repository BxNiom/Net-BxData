using System.Data;

namespace Bx.Data.Poco.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class ColumnAttribute : Attribute
{
    public ColumnAttribute(string Name, DbType DataType = DbType.String)
    {
        this.Name = Name;
        this.DataType = DataType;
    }

    public string Name { get; }
    public DbType DataType { get; }
}