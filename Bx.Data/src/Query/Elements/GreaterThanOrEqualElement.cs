namespace Bx.Data.Query.Elements;

public class GreaterThanOrEqualElement : AbstractConditionElement
{
    public GreaterThanOrEqualElement(string column, object? value) : base(ElementType.GreaterThanOrEqual, column)
    {
        Utils.CheckDigit(value);
        Value = value;
    }

    public object? Value { get; set; }
}