using System.Data.Common;
using Bx.Data.Dialect;
using Bx.Data.Poco;

namespace Bx.Data;

public class DbContext
{
    private readonly Dictionary<Type, PocoInfo> PocoInfos = new();
    public IDialect Dialect { get; set; }

    public DbConnection CreateConnection()
    {
        if (Dialect == null)
            throw new InvalidOperationException("define a dialect first");

        return Dialect.CreateConnection();
    }

    public PocoInfo GetPocoInfo<T>() where T : class
    {
        if (!PocoInfos.ContainsKey(typeof(T)))
            PocoInfos.Add(typeof(T), new PocoInfo(typeof(T)));

        return PocoInfos[typeof(T)];
    }
}