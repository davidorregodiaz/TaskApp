using TaskManager.Domain;

namespace TaskManager.Interfaces;

public interface ITaskService
{
    void CreateTask(string taskDescription);
    void UpdateTask(Guid taskId,string taskDescription);
    void DeleteTask(Guid taskId);
    void UpdateStatus(Guid taskId,string status);
    void CreateTaskTable();
    void CreateDoneTaskTable();
    void CreateInProgressTaskTable();
}