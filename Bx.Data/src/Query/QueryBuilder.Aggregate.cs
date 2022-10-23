using Bx.Data.Query.Elements;

namespace Bx.Data.Query;

public partial class QueryBuilder
{
    public QueryBuilder Min(params string[] columns)
    {
        return AddElement(new MinElement(columns));
    }

    public QueryBuilder Max(params string[] columns)
    {
        return AddElement(new MaxElement(columns));
    }

    public QueryBuilder Sum(params string[] columns)
    {
        return AddElement(new SumElement(columns));
    }

    public QueryBuilder Average(params string[] columns)
    {
        return AddElement(new AverageElement(columns));
    }

    public QueryBuilder Count(params string[] columns)
    {
        return AddElement(new CountElement(columns));
    }
}