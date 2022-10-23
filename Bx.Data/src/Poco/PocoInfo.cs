using System.Reflection;
using Bx.Data.Poco.Attributes;

namespace Bx.Data.Poco;

public class PocoInfo
{
    internal PocoInfo(Type pocoType)
    {
        var hasPrimaryKey = false;
        PrimaryKey = new PocoProperty();
        TableName = "";
        PocoType = pocoType;

        PocoConstructor = pocoType.GetConstructor(Array.Empty<Type>()) ??
                          throw new InvalidDataException($"{pocoType} has no empty constructor");

        var tableAttribute = pocoType.GetCustomAttribute<TableAttribute>();
        if (tableAttribute == null)
            throw new InvalidDataException($"{pocoType} has no table attribute");

        TableName = tableAttribute.Name;

        var columns = new List<PocoProperty>();
        var uniques = new List<PocoProperty>();
        foreach (var prop in pocoType.GetProperties())
        {
            var colAttribute = prop.GetCustomAttribute<ColumnAttribute>();
            if (colAttribute == null) continue;

            var pkAttribute = prop.GetCustomAttribute<PrimaryKeyAttribute>();
            if (pkAttribute != null && hasPrimaryKey)
                throw new InvalidDataException(
                    $"{pocoType} has more than one primary key. Which is currently not supported");

            var pocoCol = new PocoProperty(prop, colAttribute.Name, colAttribute.DataType,
                pkAttribute != null, pkAttribute?.Autoincrement ?? false);

            if (pkAttribute != null)
                PrimaryKey = pocoCol;

            columns.Add(pocoCol);
        }

        Properties = columns;
        ColumnParameters = new Dictionary<string, string>(from cp in Properties
            select new KeyValuePair<string, string>(cp.ColumnParameter.column, cp.ColumnParameter.parameter));
    }

    public Type PocoType { get; }
    public ConstructorInfo PocoConstructor { get; }
    public string TableName { get; }
    public PocoProperty PrimaryKey { get; }
    public IReadOnlyList<PocoProperty> Properties { get; }
    public IDictionary<string, string> ColumnParameters { get; }
}