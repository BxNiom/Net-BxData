namespace Bx.Data.Query.Elements;

public abstract class AbstractConditionElement : AbstractElement
{
    protected AbstractConditionElement(ElementType type, string column) : base(type)
    {
        Column = column;
    }

    public string Column { get; set; }
    public bool IsOr { get; set; }
    public bool IsNot { get; set; }
}