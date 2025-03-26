using System.Text.Json;
using TaskManager.Domain;
using TaskManager.Domain.Errors;
using TaskManager.Interfaces;
using TaskManager.UseCases.Validation;

namespace TaskManager.UseCases;

public class TaskService : ITaskService
{
    public List<TodoTask>? Tasks;
    private readonly ITaskReader _reader;
    private readonly TaskValidation _taskValidation;
    
    public TaskService(ITaskReader reader, TaskValidation taskValidation)
    {
        _reader = reader;
        Tasks = LoadTasksStored();
    }


    public void CreateTask(string createCommand)
    {
        if (!string.IsNullOrEmpty(createCommand))
        {
            var cmds = createCommand.Split(" ");
            try
            { 
                string taskDescription = string.Join(" ",cmds.Skip(2));
                TodoTask newTask = new TodoTask { Description = taskDescription };
                Tasks?.Add(newTask);
                StoreTasks(Tasks!);
                Console.WriteLine($"Created new task: {taskDescription} , Id: {newTask.Id}");
            }
            catch (AppException appException)
            {
                Console.WriteLine(appException.Message);
            }
        }
    }

    public void UpdateTask(Guid taskId,string taskDescription)
    {
        throw new NotImplementedException();
    }

    public void DeleteTask(Guid taskId)
    {
        throw new NotImplementedException();
    }
    

    public void StoreTasks(List<TodoTask> tasksToStore)
    {
        string path = "C:\\Users\\david\\RiderProjects\\TaskManager\\TaskManager\\Data";
        var jsonOptions = new JsonSerializerOptions{WriteIndented = true};
        var jsonString = JsonSerializer.Serialize(tasksToStore, jsonOptions);
        File.WriteAllText(Path.Combine(path,"tasks.json"),jsonString);
    }

    public void UpdateStatus(Guid taskId,string status)
    {
        throw new NotImplementedException();
    }

    private List<TodoTask>? LoadTasksStored()
    {
        return _reader.GetTasks();
    }
}