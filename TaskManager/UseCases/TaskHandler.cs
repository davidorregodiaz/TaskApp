using TaskManager.Domain;
using TaskManager.Domain.Errors;
using TaskManager.Interfaces;

namespace TaskManager.UseCases;

public class TaskHandler
{
    private readonly ITaskService _taskService;
    private readonly IParser<Guid,string> _parser;
    private readonly Dictionary<string, Action<string[]>> _commands;
    public TaskHandler(ITaskService taskService, IParser<Guid, string> parser)
    {
        _taskService = taskService;
        _parser = parser;
        _commands = new Dictionary<string, Action<string[]>>
        {
            { "add", CreateTask },
            { "delete", DeleteTask },
            { "update", UpdateTask },
            {"inprogress",UpdateStatus},
            {"done",UpdateStatus},
            {"list-done",TaskListDone},
            {"list",TaskList},
            {"list-in-progress",TaskListInProgress},
        };
    }

    public bool HandleTask(string[] cmds)
    {
        if(cmds[0]!="task-cli") throw new AppException(TaskError.NoSuchCommand);

        var command = cmds[1].ToLower();
        
        if(!_commands.ContainsKey(command)) throw new AppException(TaskError.NoSuchCommand);

        _commands[command](cmds);
        
        return true;
    }
   
    
    private void CreateTask(string[] cmds)
    {
        if (string.IsNullOrWhiteSpace(cmds[2]))
        {
            throw new AppException(TaskError.NoSuchCommand);
        }
        _taskService.CreateTask(string.Join(" ",cmds.Skip(2)));
    }
    
    private void DeleteTask(string[] cmds)
    {
        var taskId = _parser.Parse(cmds[2]);
        _taskService.DeleteTask(taskId);
    }
    private void UpdateTask(string[] cmds)
    {
        var taskId = _parser.Parse(cmds[2]);
        _taskService.UpdateTask(taskId, cmds[1]);
    }

    private void UpdateStatus(string[] cmds)
    { 
        var taskId = _parser.Parse(cmds[2]);
        _taskService.UpdateStatus(taskId,cmds[1].ToLower());
    }

    private void TaskList(string[]? cmds)
    {
        _taskService.CreateTaskTable();
    }
    
    private void TaskListDone(string[]? cmds)
    {
        _taskService.CreateDoneTaskTable();
    }
    private void TaskListInProgress(string[]? cmds)
    {
        _taskService.CreateInProgressTaskTable();
    }
}