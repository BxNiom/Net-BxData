namespace Bx.Data.Query.Elements;

public class OrderByElement : AbstractElement
{
    public OrderByElement(bool ascending, params string[] columns) : base(ElementType.OrderBy)
    {
        Ascending = ascending;
        Columns = columns;
    }

    public IReadOnlyCollection<string> Columns { get; }
    public bool Ascending { get; set; }
}