namespace TaskManager.Domain.Errors;

public static class TaskError
{
    public static readonly Error NoSuchCommand = new Error("Invalid Input", "No such command");
    public static readonly Error NoSuchTask = new Error("Not Found", "No such task");
    public static readonly Error FileNotFound = new Error("Not Found", "File Not Found in the directory");
}