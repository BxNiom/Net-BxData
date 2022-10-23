namespace Bx.Data.Query.Elements;

public class InsertElement : AbstractElement
{
    public InsertElement(Dictionary<string, object?> columnValues) : base(ElementType.Insert)
    {
        ColumnAndValues = columnValues;
    }

    public IReadOnlyDictionary<string, object?> ColumnAndValues { get; }
}