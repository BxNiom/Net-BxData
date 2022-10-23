namespace Bx.Data.Query;

public static class Utils
{
    public static Type[] DigitTypes =
    {
        typeof(short),
        typeof(ushort),
        typeof(int),
        typeof(uint),
        typeof(long),
        typeof(ulong),
        typeof(float),
        typeof(double),
        typeof(decimal)
    };

    public static bool IsDigit(object o)
    {
        return IsDigitType(o.GetType());
    }

    public static bool IsDigitType(Type t)
    {
        return DigitTypes.Contains(t);
    }

    public static void CheckDigit(object? o)
    {
        if (o == null || !IsDigit(o))
            throw new ArgumentException("Need an digit");
    }
}