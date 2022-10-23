namespace Bx.Data.Query.Elements;

public class UpdateElement : AbstractElement
{
    public UpdateElement(Dictionary<string, object?> columnValues) : base(ElementType.Update)
    {
        ColumnsAndValues = columnValues;
    }

    public IReadOnlyDictionary<string, object?> ColumnsAndValues { get; }
}