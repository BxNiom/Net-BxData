using System.Data.Common;
using Bx.Data.Dialect;
using Microsoft.Data.Sqlite;

namespace Bx.Data.Dialects.Sqlite;

public class SqliteDialect : AbstractDialect
{
    public SqliteDialect(string dbFilename)
    {
        ConnectionString = $"Data Source={dbFilename}";
    }

    public override bool InsertReturn => true;
    public override string LastIdQuery => "SELECT last_insert_rowid();";
    public override string InsertQuery => "INSERT INTO {table}({columns}) VALUES({values}) RETURNING {return};";
    public string ConnectionString { get; }

    public override DbConnection CreateConnection()
    {
        return new SqliteConnection(ConnectionString);
    }

    public override object CreateParameter(string name, object? value)
    {
        return new SqliteParameter(name, value);
    }
}