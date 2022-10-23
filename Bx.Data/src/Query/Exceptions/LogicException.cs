using System.Runtime.Serialization;

namespace Bx.Data.Query.Exceptions;

public class LogicException : Exception
{
    public LogicException()
    {
    }

    protected LogicException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public LogicException(string? message) : base(message)
    {
    }

    public LogicException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}