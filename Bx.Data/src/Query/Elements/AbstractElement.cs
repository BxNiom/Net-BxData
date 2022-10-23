namespace Bx.Data.Query.Elements;

public abstract class AbstractElement : IElement
{
    public AbstractElement(ElementType type)
    {
        Type = type;
    }

    public ElementType Type { get; }
}