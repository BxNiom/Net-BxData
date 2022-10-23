namespace Bx.Data.Dialects.Sqlite;

public static class SqliteContextEx
{
    public static DbContext UseSqlite(this DbContext context, string dbFilename)
    {
        context.Dialect = new SqliteDialect(dbFilename);
        return context;
    }
}