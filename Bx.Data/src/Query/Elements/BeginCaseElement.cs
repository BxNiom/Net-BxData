namespace Bx.Data.Query.Elements;

public class BeginCaseElement : AbstractElement
{
    public BeginCaseElement(string? column = null) : base(ElementType.BeginCase)
    {
        Column = column;
    }

    public string? Column { get; set; }
}