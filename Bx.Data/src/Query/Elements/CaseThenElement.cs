namespace Bx.Data.Query.Elements;

public class CaseThenElement : AbstractElement
{
    public CaseThenElement(object? value) : base(ElementType.CaseThen)
    {
        Value = value;
    }

    public object? Value { get; }
}