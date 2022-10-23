namespace Bx.Data.Query.Elements;

public class InElement : AbstractConditionElement
{
    public IReadOnlyCollection<object?> Values;

    public InElement(string column, params object?[] values) : base(ElementType.In, column)
    {
        Values = values;
    }
}