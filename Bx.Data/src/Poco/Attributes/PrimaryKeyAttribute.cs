namespace Bx.Data.Poco.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class PrimaryKeyAttribute : Attribute
{
    public PrimaryKeyAttribute(bool Autoincrement = true)
    {
        this.Autoincrement = Autoincrement;
    }

    public bool Autoincrement { get; }
}