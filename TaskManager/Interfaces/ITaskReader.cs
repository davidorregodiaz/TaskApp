using TaskManager.Domain;

namespace TaskManager.Interfaces;

public interface ITaskReader
{
    List<TodoTask>? GetTasks(); 
}