namespace Bx.Data.Poco.Attributes;

public class ForeignKeyAttribute : Attribute
{
    public Type ReferenceType { get; }
    public string PropertyName { get; }
}