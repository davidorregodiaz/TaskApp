using TaskManager.Domain;

namespace TaskManager.Interfaces;

public interface ITaskService
{
    void CreateTask(string taskDescription);
    void UpdateTask(string taskId);
    void DeleteTask(string taskId);
    void StoreTasks(List<TodoTask> tasksToStore);
    void UpdateStatus(string taskId,string status);
}