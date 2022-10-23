namespace Bx.Data.Query.Elements;

public class EndCaseElement : AbstractElement
{
    public EndCaseElement(string? alias = null) : base(ElementType.EndCase)
    {
        Alias = alias;
    }

    public string? Alias { get; }
}