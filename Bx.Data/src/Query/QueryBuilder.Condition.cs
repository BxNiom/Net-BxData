using Bx.Data.Query.Elements;

namespace Bx.Data.Query;

public partial class QueryBuilder
{
    public QueryBuilder IsEqual(string column, object? value)
    {
        return AddElement(new EqualElement(column, value));
    }

    public QueryBuilder IsLessThan(string column, object? value)
    {
        return AddElement(new LessThanElement(column, value));
    }

    public QueryBuilder IsLessThanOrEqual(string column, object? value)
    {
        return AddElement(new LessThanOrEqualElement(column, value));
    }

    public QueryBuilder IsGreaterThan(string column, object? value)
    {
        return AddElement(new GreaterThanElement(column, value));
    }

    public QueryBuilder IsGreaterThanOrEqual(string column, object? value)
    {
        return AddElement(new GreaterThanOrEqualElement(column, value));
    }

    public QueryBuilder IsNull(string column)
    {
        return AddElement(new IsNullElement(column));
    }

    public QueryBuilder IsIn(string column, params object?[] values)
    {
        return AddElement(new InElement(column, values));
    }

    public QueryBuilder IsLike(string column, string term)
    {
        return AddElement(new LikeElement(column, term));
    }
}