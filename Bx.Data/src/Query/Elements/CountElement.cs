namespace Bx.Data.Query.Elements;

public class CountElement : AbstractAggregateElement
{
    public CountElement(params string[] columns) : base(ElementType.Count, columns)
    {
    }
}