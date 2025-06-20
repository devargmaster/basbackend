namespace Exceptions.Types;

public class DomainException
{
    public string ErrorType { get; set; }
    public string[] Values { get; set; }
    public string? ErrorText { get; set; }

    public DomainException(string type, params string[] values)
    {
        ErrorType = type;
        Values = values;
    }

    public DomainException(string type)
        : this(type, Array.Empty<string>())
    {
    }
}