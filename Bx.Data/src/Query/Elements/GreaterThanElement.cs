namespace Bx.Data.Query.Elements;

public class GreaterThanElement : AbstractConditionElement
{
    public GreaterThanElement(string column, object? value) : base(ElementType.GreaterThan, column)
    {
        Utils.CheckDigit(value);
        Value = value;
    }

    public object? Value { get; set; }
}