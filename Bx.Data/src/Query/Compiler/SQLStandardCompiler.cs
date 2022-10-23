using Bx.Data.Query.Elements;

namespace Bx.Data.Query.Compiler;

public class SQLStandardCompiler : ICompiler
{
    public string CompileAll(CompilerTask task, AllElement element)
    {
        throw new NotImplementedException();
    }

    public string CompileAs(CompilerTask task, AsElement element)
    {
        return $"AS {element.Name}";
    }

    public string CompileAverage(CompilerTask task, AverageElement element)
    {
        return $"AVG({string.Join(", ", element.Columns)})";
    }

    public string CompileBeginCase(CompilerTask task, BeginCaseElement element)
    {
        return $"CASE {element.Column}";
    }

    public string CompileBetween(CompilerTask task, BetweenElement element)
    {
        return $"{element.Column} BETWEEN {element.Min} AND {element.Max}";
    }

    public string CompileCaseElse(CompilerTask task, CaseElseElement element)
    {
        return $"ELSE {task.AddParameter("CASE_ELSE", element.Value)}";
    }

    public string CompileCaseThen(CompilerTask task, CaseThenElement element)
    {
        return $"THEN {task.AddParameter("CASE_THEN", element.Value)}";
    }

    public string CompileCount(CompilerTask task, CountElement element)
    {
        return $"COUNT({string.Join(", ", element.Columns)})";
    }

    public string CompileCustom(CompilerTask task, CustomElement element)
    {
        return "";
    }

    public string CompileDelete(CompilerTask task, DeleteElement element)
    {
        return $"DELETE FROM {task.Query.TableName}";
    }

    public string CompileDistinct(CompilerTask task, DistinctElement element)
    {
        return "";
    }

    public string CompileEndCase(CompilerTask task, EndCaseElement element)
    {
        return $"END {element.Alias}";
    }

    public string CompileEqual(CompilerTask task, EqualElement element)
    {
        return element.IsNot
            ? $"{element.Column} <> {task.AddParameter("EQ", element.Value)}"
            : $"{element.Column} = {task.AddParameter("EQ", element.Value)}";
    }

    public string CompileGreaterThan(CompilerTask task, GreaterThanElement element)
    {
        return (element.IsNot ? "NOT " : "") + $"{element.Column} > {task.AddParameter("GT", element.Value)}";
    }

    public string CompileGreaterThanOrEqual(CompilerTask task, GreaterThanOrEqualElement element)
    {
        return (element.IsNot ? "NOT " : "") + $"{element.Column} >= {task.AddParameter("GTE", element.Value)}";
    }

    public string CompileGroupBy(CompilerTask task, GroupByElement element)
    {
        return $"GROUP BY ({string.Join(", ", element.Columns)}";
    }

    public string CompileHaving(CompilerTask task, HavingElement element)
    {
        throw new NotImplementedException();
    }

    public string CompileIn(CompilerTask task, InElement element)
    {
        var parameters = from v in element.Values
            select task.AddParameter("IN", v);

        return $"{element.Column}{(element.IsNot ? " NOT" : "")} IN ({string.Join(", ", parameters)})";
    }

    public string CompileInsert(CompilerTask task, InsertElement element)
    {
        return $"INSERT INTO {task.Query.TableName} ("
               + string.Join(", ", element.ColumnAndValues.Keys)
               + ") VALUES ("
               + string.Join(", ", element.ColumnAndValues.Select(pair =>
                   task.AddParameter("INS", pair.Value)))
               + ")";
    }

    public string CompileIsNull(CompilerTask task, IsNullElement element)
    {
        return $"{element.Column} IS{(element.IsNot ? " NOT" : "")} NULL";
    }

    public string CompileJoin(CompilerTask task, JoinElement element)
    {
        throw new NotImplementedException();
    }

    public string CompileLessThan(CompilerTask task, LessThanElement element)
    {
        return (element.IsNot ? "NOT " : "") + $"{element.Column} < {task.AddParameter("LT", element.Value)}";
    }

    public string CompileLessThanOrEqual(CompilerTask task, LessThanOrEqualElement element)
    {
        return (element.IsNot ? "NOT " : "") + $"{element.Column} <= {task.AddParameter("LTE", element.Value)}";
    }

    public string CompileLike(CompilerTask task, LikeElement element)
    {
        return $"{element.Column} LIKE {task.AddParameter("LIKE", element.Term)}";
    }

    public string CompileLimit(CompilerTask task, LimitElement element)
    {
        return $"LIMIT {element.Limit}";
    }

    public string CompileMax(CompilerTask task, MaxElement element)
    {
        return $"MAX({string.Join(", ", element.Columns)})";
    }

    public string CompileMin(CompilerTask task, MinElement element)
    {
        return $"MIN({string.Join(", ", element.Columns)})";
    }

    public string CompileOffset(CompilerTask task, OffsetElement element)
    {
        return $"OFFSET {element.Offset}";
    }

    public string CompileOrderBy(CompilerTask task, OrderByElement element)
    {
        return $"ORDER BY ({string.Join(", ", element.Columns)}) {(element.Ascending ? "ASC" : "DESC")}";
    }

    public string CompileReturning(CompilerTask task, ReturningElement element)
    {
        return "";
    }

    public string CompileSelect(CompilerTask task, SelectElement element)
    {
        return "SELECT "
               + (task.Query.ContainsElement(ElementType.Distinct) ? "DISTINCT " : "")
               + (element.Columns.Any() ? string.Join(", ", element.Columns) : "*")
               + $" FROM {task.Query.TableName}";
    }

    public string CompileSum(CompilerTask task, SumElement element)
    {
        return $"SUM({string.Join(", ", element.Columns)})";
    }

    public string CompileUnion(CompilerTask task, UnionElement element)
    {
        throw new NotImplementedException();
    }

    public string CompileUpdate(CompilerTask task, UpdateElement element)
    {
        return $"UPDATE {task.Query.TableName} SET "
               + string.Join(", ",
                   element.ColumnsAndValues.Select(pair =>
                       $"{pair.Key} = {task.AddParameter("UPD", pair.Value)}"));
    }

    public string CompileWhere(CompilerTask task, WhereElement element)
    {
        return "WHERE";
    }
}