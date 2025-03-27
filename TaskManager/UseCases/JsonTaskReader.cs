using System.Text.Json;
using TaskManager.Domain;
using TaskManager.Domain.Errors;
using TaskManager.Interfaces;

namespace TaskManager.UseCases;

public class JsonTaskReader : ITaskReader
{
    public List<TodoTask>? GetTasks()
    {
        string projectRoot = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
        string dataFolder = Path.Combine(projectRoot, "Data");
        string filePath = Path.Combine(dataFolder, "tasks.json");
        
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath,"[]");
            return new List<TodoTask>();
        }

        try
        {
            var tasks = JsonSerializer.Deserialize<List<TodoTask>>(File.ReadAllText(filePath));
            return tasks;
        }
        catch (JsonException jsonException)
        {
            return new List<TodoTask>();
        }
    }

    public void Store(List<TodoTask> tasksToStore)
    {
        string projectRoot = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
        string dataFolder = Path.Combine(projectRoot, "Data");
        string filePath = Path.Combine(dataFolder, "tasks.json");
        var jsonOptions = new JsonSerializerOptions{WriteIndented = true};
        var jsonString = JsonSerializer.Serialize(tasksToStore, jsonOptions);
        try
        {
            File.WriteAllText(filePath, jsonString);
        }
        catch (ArgumentException argumentException)
        {
            Console.WriteLine(argumentException.Message);
        }
    }
}