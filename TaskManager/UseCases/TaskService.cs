using System.Text.Json;
using ConsoleTables;
using TaskManager.Domain;
using TaskManager.Domain.Errors;
using TaskManager.Interfaces;
using TaskManager.Util;

namespace TaskManager.UseCases;

public class TaskService : ITaskService
{
    private readonly List<TodoTask>? _tasks;
    private readonly ITaskReader _reader;
    
    public TaskService(ITaskReader reader)
    {
        _reader = reader;
        _tasks = _reader.GetTasks();
    }


    public void CreateTask(string taskDescription)
    {
        if (!string.IsNullOrEmpty(taskDescription))
        {
            TodoTask newTask = new TodoTask { Description = taskDescription };
            _tasks?.Add(newTask);
            _reader.Store(_tasks!);
            Message.PrintInfo($"Created new task: {taskDescription} , Id: {newTask.Id}");
        }
    }
    public void UpdateTask(Guid taskId,string taskDescription)
    {
        if (_tasks is not null)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task is not null)
            {
                task.Description = taskDescription;
                task.UpdatedAt = DateTime.UtcNow;
                _reader.Store(_tasks!);
                Message.PrintUpdate($"Update: {task.Description} , Id: {task.Id}");
                return;
            }
            Message.PrintError("Task not found");
        }
    }
    public void DeleteTask(Guid taskId)
    {
        if (_tasks is not null)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task is not null)
            {
                _tasks.Remove(task);
                _reader.Store(_tasks!);
                Message.PrintSuccess($"Deleted {task.Description} , Id: {task.Id}");
                return;
            }
            Message.PrintError("Task not found");
        }
    }
    public void UpdateStatus(Guid taskId,string status)
    {
        if (_tasks is not null)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task is not null)
            {
                if (Enum.TryParse<Status>(status, true, out var taskStatus))
                {
                    task.Status = taskStatus;
                    task.UpdatedAt = DateTime.UtcNow;
                    _reader.Store(_tasks!);
                    Message.PrintUpdate($"Updated: {taskStatus} , Id: {taskId}");
                }
                else
                {
                    Message.PrintError("Invalid command");
                }
            }
            else
            {
                Message.PrintError("Task not found");
            }
        }
    }

    public void CreateTaskTable()
    {
        var table = new ConsoleTable("ID", "Description", "Status" , "CreatedAt", "UpdatedAt");
        foreach (var task in _tasks)
        {
            table.AddRow(task.Id, task.Description, task.Status, task.CreatedAt,task.UpdatedAt);
        }
        table.Write();
    }

    public void CreateDoneTaskTable()
    {
        var table = new ConsoleTable("ID", "Description", "Status" , "CreatedAt", "UpdatedAt");
        foreach (var task in _tasks.Where(t => t.Status == Status.Done))
        {
            table.AddRow(task.Id, task.Description, task.Status, task.CreatedAt,task.UpdatedAt);
        }
        table.Write();
    }

    public void CreateInProgressTaskTable()
    {
        var table = new ConsoleTable("ID", "Description", "Status" , "CreatedAt", "UpdatedAt");
        foreach (var task in _tasks.Where(t => t.Status == Status.InProgress))
        {
            table.AddRow(task.Id, task.Description, task.Status, task.CreatedAt,task.UpdatedAt);
        }
        table.Write();
    }
}