namespace TaskManager.Domain.Errors;

public class AppException : Exception
{
    public Error ErrorMessage { get; }

    public AppException(Error error) : base(error.Message)
    {
        ErrorMessage = error;
    }
}