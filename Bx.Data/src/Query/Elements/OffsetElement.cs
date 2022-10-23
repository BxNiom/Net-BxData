namespace Bx.Data.Query.Elements;

public class OffsetElement : AbstractElement
{
    public OffsetElement(object offset) : base(ElementType.Offset)
    {
        Utils.CheckDigit(offset);
        Offset = offset;
    }

    public object Offset { get; }
}