namespace Bx.Data.Query.Elements;

public class MaxElement : AbstractAggregateElement
{
    public MaxElement(params string[] columns) : base(ElementType.Max, columns)
    {
    }
}