using System.Data.Common;

namespace Bx.Data.Query;

public partial class QueryBuilder
{
    public string Compile()
    {
        return string.Empty;
    }

    public DbCommand CompileCommand()
    {
        return null;
    }
}