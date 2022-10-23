namespace Bx.Data.Query.Elements;

public class AsElement : AbstractElement
{
    public AsElement(string name) : base(ElementType.As)
    {
        Name = name;
    }

    public string Name { get; }
}