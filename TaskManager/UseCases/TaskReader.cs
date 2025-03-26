using System.Text.Json;
using TaskManager.Domain;
using TaskManager.Interfaces;

namespace TaskManager.UseCases;

public class TaskReader : ITaskReader
{
    public List<TodoTask>? GetTasks()
    {
        string path = "C:\\Users\\david\\RiderProjects\\TaskManager\\TaskManager\\Data";
        
        if (!File.Exists(path))
        {
            File.WriteAllText(Path.Combine(path,"tasks.json"),"[]");
            return new List<TodoTask>();
            
        }

        try
        {
            var tasks = JsonSerializer.Deserialize<List<TodoTask>>(File.ReadAllText("tasks.json"));
            return tasks;
        }
        catch (JsonException jsonException)
        {
            return new List<TodoTask>();
        }
        
    }
}