namespace Bx.Data.Query.Elements;

public class IsNullElement : AbstractConditionElement
{
    public IsNullElement(string column) : base(ElementType.IsNull, column)
    {
    }
}