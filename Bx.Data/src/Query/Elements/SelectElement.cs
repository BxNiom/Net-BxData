namespace Bx.Data.Query.Elements;

public class SelectElement : AbstractElement
{
    public SelectElement(params string[] columns) : base(ElementType.Select)
    {
        Columns = columns;
    }

    public IReadOnlyCollection<string> Columns { get; }
}