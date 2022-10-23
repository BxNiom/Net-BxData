using Bx.Data.Query.Compiler;
using Bx.Data.Query.Elements;

namespace Bx.Data.Query;

public interface ICompiler
{
    string CompileAll(CompilerTask task, AllElement element);
    string CompileAs(CompilerTask task, AsElement element);
    string CompileAverage(CompilerTask task, AverageElement element);
    string CompileBeginCase(CompilerTask task, BeginCaseElement element);
    string CompileBetween(CompilerTask task, BetweenElement element);
    string CompileCaseElse(CompilerTask task, CaseElseElement element);
    string CompileCaseThen(CompilerTask task, CaseThenElement element);
    string CompileCount(CompilerTask task, CountElement element);
    string CompileCustom(CompilerTask task, CustomElement element);
    string CompileDelete(CompilerTask task, DeleteElement element);
    string CompileDistinct(CompilerTask task, DistinctElement element);
    string CompileEndCase(CompilerTask task, EndCaseElement element);
    string CompileEqual(CompilerTask task, EqualElement element);
    string CompileGreaterThan(CompilerTask task, GreaterThanElement element);
    string CompileGreaterThanOrEqual(CompilerTask task, GreaterThanOrEqualElement element);
    string CompileGroupBy(CompilerTask task, GroupByElement element);
    string CompileHaving(CompilerTask task, HavingElement element);
    string CompileIn(CompilerTask task, InElement element);
    string CompileInsert(CompilerTask task, InsertElement element);
    string CompileIsNull(CompilerTask task, IsNullElement element);
    string CompileJoin(CompilerTask task, JoinElement element);
    string CompileLessThan(CompilerTask task, LessThanElement element);
    string CompileLessThanOrEqual(CompilerTask task, LessThanOrEqualElement element);
    string CompileLike(CompilerTask task, LikeElement element);
    string CompileLimit(CompilerTask task, LimitElement element);
    string CompileMax(CompilerTask task, MaxElement element);
    string CompileMin(CompilerTask task, MinElement element);
    string CompileOffset(CompilerTask task, OffsetElement element);
    string CompileOrderBy(CompilerTask task, OrderByElement element);
    string CompileReturning(CompilerTask task, ReturningElement element);
    string CompileSelect(CompilerTask task, SelectElement element);
    string CompileSum(CompilerTask task, SumElement element);
    string CompileUnion(CompilerTask task, UnionElement element);
    string CompileUpdate(CompilerTask task, UpdateElement element);
    string CompileWhere(CompilerTask task, WhereElement element);
}