using System.Runtime.Serialization;

namespace Bx.Data.Query.Exceptions;

public class MethodException : Exception
{
    public MethodException()
    {
    }

    protected MethodException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MethodException(string? message) : base(message)
    {
    }

    public MethodException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}