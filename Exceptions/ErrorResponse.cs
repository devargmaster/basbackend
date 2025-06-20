namespace Exceptions;

public class ErrorResponse
{
    #region Properties

    public int Code { get; }

    public string[] Messages { get; }

    public string TraceId { get; }

    #endregion

    #region Constructor

    public ErrorResponse(int code, string[] messages, string traceId)
    {
        Code = code;
        Messages = messages;
        TraceId = traceId;
    }

    #endregion

    public class ExceptionResponse : ErrorResponse
    {
        public string Exception { get; }

        public ExceptionResponse(int code, string[] messages, string traceId, string exception)
            : base(code, messages, traceId)
        {
            Exception = exception;
        }
    }
} 