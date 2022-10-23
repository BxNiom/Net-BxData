using Bx.Data.Query.Elements;

namespace Bx.Data.Query;

public partial class QueryBuilder
{
    private readonly List<IElement> _elements;

    public QueryBuilder(string tableName, DbContext context)
    {
        _elements = new List<IElement>();
        IsOr = false;
        IsNot = false;
        Context = context;
    }

    protected bool IsOr { get; set; }
    protected bool IsNot { get; set; }

    protected IElement? LastElement => _elements.LastOrDefault();
    protected IElement? FirstElement => _elements.FirstOrDefault();
    public IReadOnlyList<IElement> Elements => _elements;

    public DbContext Context { get; }
    public string TableName { get; }

    protected QueryBuilder AddElement(IElement element)
    {
        if (element is AbstractConditionElement ace)
        {
            ace.IsNot = IsNot;
            ace.IsOr = IsOr;
        }

        IsOr = IsNot = false;
        _elements.Add(element);

        return this;
    }

    public QueryBuilder Reset()
    {
        _elements.Clear();
        IsOr = IsNot = false;
        return this;
    }

    public bool ContainsElement(ElementType type)
    {
        return (from ele in _elements
            where ele.Type == type
            select ele).Any();
    }

    public QueryBuilder Or()
    {
        IsOr = true;
        return this;
    }

    public QueryBuilder And()
    {
        IsOr = false;
        return this;
    }

    public QueryBuilder Not()
    {
        IsNot = !IsNot;
        return this;
    }

    public QueryBuilder As(string name)
    {
        return AddElement(new AsElement(name));
    }
}