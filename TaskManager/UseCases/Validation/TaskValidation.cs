using TaskManager.Domain.Errors;

namespace TaskManager.UseCases.Validation;

public class TaskValidation
{
    public bool ValidateTask(string[] cmds)
    {
        if(cmds[0]!="task-cli") throw new AppException(TaskError.NoSuchCommand);
        
        if(!(cmds[1] != "add" || cmds[1] != "update" || cmds[1] != "delete")) throw new AppException(TaskError.NoSuchCommand);
        
        if (cmds[1] == "update" || cmds[1] == "delete")
        {
            try
            {
                int taskId = int.Parse(cmds[2]);
            }
            catch (FormatException formatException)
            {
                throw new FormatException("Invalid task id", formatException);
            }
        }
        return true;
    }
}