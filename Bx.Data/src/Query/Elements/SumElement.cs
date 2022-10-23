namespace Bx.Data.Query.Elements;

public class SumElement : AbstractAggregateElement
{
    public SumElement(params string[] columns) : base(ElementType.Sum, columns)
    {
    }
}