namespace Bx.Data.Query.Elements;

public class LessThanElement : AbstractConditionElement
{
    public LessThanElement(string column, object? value) : base(ElementType.LessThan, column)
    {
        Utils.CheckDigit(value);
        Value = value;
    }

    public object? Value { get; set; }
}