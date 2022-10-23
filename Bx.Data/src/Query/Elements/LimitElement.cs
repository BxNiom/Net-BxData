namespace Bx.Data.Query.Elements;

public class LimitElement : AbstractElement
{
    public LimitElement(object limit) : base(ElementType.Limit)
    {
        Utils.CheckDigit(limit);
        Limit = limit;
    }

    public object Limit { get; }
}