namespace TaskManager.Domain.Errors;

public sealed record Error(string Code, string Message)
{
    public static readonly Error None = new(String.Empty, string.Empty);
}