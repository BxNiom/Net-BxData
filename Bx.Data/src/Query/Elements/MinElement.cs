namespace Bx.Data.Query.Elements;

public class MinElement : AbstractAggregateElement
{
    public MinElement(params string[] columns) : base(ElementType.Min, columns)
    {
    }
}