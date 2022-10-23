namespace Bx.Data.Query.Elements;

public class EqualElement : AbstractConditionElement
{
    public EqualElement(string column, object? value) : base(ElementType.Equal, column)
    {
        Value = value;
    }

    public object? Value { get; set; }
}