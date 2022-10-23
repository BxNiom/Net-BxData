namespace Bx.Data.Query.Elements;

public class LessThanOrEqualElement : AbstractConditionElement
{
    public LessThanOrEqualElement(string column, object? value) : base(ElementType.LessThanOrEqual, column)
    {
        Utils.CheckDigit(value);
        Value = value;
    }

    public object? Value { get; set; }
}