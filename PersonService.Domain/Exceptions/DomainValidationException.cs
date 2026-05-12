namespace PersonService.Domain.Exceptions;

public sealed class DomainValidationException : Exception
{
    public IReadOnlyCollection<string> Errors { get; }

    public DomainValidationException()
    {
    }

    public DomainValidationException(string message) : base(message)
    {
        Errors = new[] { message };
    }

    public DomainValidationException(IEnumerable<string> errors)
        : base(string.Join("; ", errors))
    {
        if (errors == null || !errors.Any())
            throw new ArgumentException("No error message provided", nameof(errors));
        Errors = errors.ToList().AsReadOnly();
    }

}