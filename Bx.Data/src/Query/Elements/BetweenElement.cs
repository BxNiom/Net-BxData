namespace Bx.Data.Query.Elements;

public class BetweenElement : AbstractConditionElement
{
    public BetweenElement(string column, object? min, object? max) : base(ElementType.Between, column)
    {
        Utils.CheckDigit(min);
        Min = min;
        Utils.CheckDigit(max);
        Max = max;
    }

    public object? Min { get; set; }
    public object? Max { get; set; }
}