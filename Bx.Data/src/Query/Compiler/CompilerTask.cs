using System.Data.Common;
using Bx.Data.Query.Elements;

namespace Bx.Data.Query.Compiler;

public class CompilerTask
{
    private readonly List<string> _aliases;
    private readonly Dictionary<string, int> _parameterNames;
    private readonly Dictionary<string, object?> _parameters;

    public CompilerTask(QueryBuilder query, ICompiler? compiler = null)
    {
        Query = query;
        Compiler = compiler ?? Context.Dialect.QueryCompiler ?? new SQLStandardCompiler();

        _aliases = new List<string>();
        _parameters = new Dictionary<string, object?>();
        _parameterNames = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
    }

    public QueryBuilder Query { get; }
    public DbContext Context => Query.Context;
    public ICompiler Compiler { get; }

    public IReadOnlyList<string> Aliases { get; }
    public IReadOnlyDictionary<string, object?> Parameters { get; }

    public string GetParameterName(string postfix)
    {
        postfix = postfix.ToUpper();
        if (!_parameterNames.ContainsKey(postfix))
            _parameterNames.Add(postfix, 0);

        return $"@_{postfix}_{++_parameterNames[postfix]}";
    }

    public string AddParameter(string postfix, object? value)
    {
        var paramName = GetParameterName(postfix);
        _parameters.Add(paramName, value);
        return paramName;
    }

    public string Compile()
    {
        var parts = new List<string>();
        foreach (var element in Query.Elements)
        {
            var part = element.Type switch
            {
                ElementType.All => Compiler.CompileAll(this, (AllElement)element),
                ElementType.As => Compiler.CompileAs(this, (AsElement)element),
                ElementType.Average => Compiler.CompileAverage(this, (AverageElement)element),
                ElementType.BeginCase => Compiler.CompileBeginCase(this, (BeginCaseElement)element),
                ElementType.Between => Compiler.CompileBetween(this, (BetweenElement)element),
                ElementType.CaseElse => Compiler.CompileCaseElse(this, (CaseElseElement)element),
                ElementType.CaseThen => Compiler.CompileCaseThen(this, (CaseThenElement)element),
                ElementType.Count => Compiler.CompileCount(this, (CountElement)element),
                ElementType.Custom => Compiler.CompileCustom(this, (CustomElement)element),
                ElementType.Delete => Compiler.CompileDelete(this, (DeleteElement)element),
                ElementType.Distinct => Compiler.CompileDistinct(this, (DistinctElement)element),
                ElementType.EndCase => Compiler.CompileEndCase(this, (EndCaseElement)element),
                ElementType.Equal => Compiler.CompileEqual(this, (EqualElement)element),
                ElementType.GreaterThan => Compiler.CompileGreaterThan(this, (GreaterThanElement)element),
                ElementType.GreaterThanOrEqual =>
                    Compiler.CompileGreaterThanOrEqual(this, (GreaterThanOrEqualElement)element),
                ElementType.GroupBy => Compiler.CompileGroupBy(this, (GroupByElement)element),
                ElementType.Having => Compiler.CompileHaving(this, (HavingElement)element),
                ElementType.In => Compiler.CompileIn(this, (InElement)element),
                ElementType.Insert => Compiler.CompileInsert(this, (InsertElement)element),
                ElementType.IsNull => Compiler.CompileIsNull(this, (IsNullElement)element),
                ElementType.Join => Compiler.CompileJoin(this, (JoinElement)element),
                ElementType.LessThan => Compiler.CompileLessThan(this, (LessThanElement)element),
                ElementType.LessThanOrEqual => Compiler.CompileLessThanOrEqual(this, (LessThanOrEqualElement)element),
                ElementType.Like => Compiler.CompileLike(this, (LikeElement)element),
                ElementType.Limit => Compiler.CompileLimit(this, (LimitElement)element),
                ElementType.Max => Compiler.CompileMax(this, (MaxElement)element),
                ElementType.Min => Compiler.CompileMin(this, (MinElement)element),
                ElementType.Offset => Compiler.CompileOffset(this, (OffsetElement)element),
                ElementType.OrderBy => Compiler.CompileOrderBy(this, (OrderByElement)element),
                ElementType.Returning => Compiler.CompileReturning(this, (ReturningElement)element),
                ElementType.Select => Compiler.CompileSelect(this, (SelectElement)element),
                ElementType.Sum => Compiler.CompileSum(this, (SumElement)element),
                ElementType.Union => Compiler.CompileUnion(this, (UnionElement)element),
                ElementType.Update => Compiler.CompileUpdate(this, (UpdateElement)element),
                _ => throw new ArgumentOutOfRangeException()
            };

            if (!string.IsNullOrEmpty(part))
            {
                if (element.Type == ElementType.As)
                    _aliases.Add(((AsElement)element).Name);

                parts.Add(part.Trim());
            }
        }

        return string.Join(" ", parts);
    }

    public DbCommand CompileCommand(DbConnection? connection = null)
    {
        connection ??= Context.CreateConnection();
        var cmd = connection.CreateCommand();
        cmd.CommandText = Compile();

        foreach (var (key, value) in Parameters)
            cmd.Parameters.Add(Context.Dialect.CreateParameter(key, value));

        return cmd;
    }
}