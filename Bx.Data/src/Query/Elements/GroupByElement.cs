namespace Bx.Data.Query.Elements;

public class GroupByElement : AbstractElement
{
    public GroupByElement(params string[] columns) : base(ElementType.GroupBy)
    {
        Columns = columns;
    }

    public IReadOnlyCollection<string> Columns { get; }
}