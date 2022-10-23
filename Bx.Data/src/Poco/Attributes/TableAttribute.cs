namespace Bx.Data.Poco.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class TableAttribute : Attribute
{
    public TableAttribute(string Name)
    {
        this.Name = Name;
    }

    public string Name { get; }
}