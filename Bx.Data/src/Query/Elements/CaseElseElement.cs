namespace Bx.Data.Query.Elements;

public class CaseElseElement : AbstractElement
{
    public CaseElseElement(object? value) : base(ElementType.CaseElse)
    {
        Value = value;
    }

    public object? Value { get; }
}