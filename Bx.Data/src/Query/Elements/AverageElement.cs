namespace Bx.Data.Query.Elements;

public class AverageElement : AbstractAggregateElement
{
    public AverageElement(params string[] columns) : base(ElementType.Average, columns)
    {
    }
}