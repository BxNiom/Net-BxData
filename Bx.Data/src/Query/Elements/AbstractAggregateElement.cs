namespace Bx.Data.Query.Elements;

public abstract class AbstractAggregateElement : AbstractElement
{
    protected AbstractAggregateElement(ElementType type, params string[] columns) : base(type)
    {
        Columns = columns;
    }

    public IReadOnlyCollection<string> Columns { get; }
}