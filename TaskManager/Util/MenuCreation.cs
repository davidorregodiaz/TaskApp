using TaskManager.Interfaces;
using TaskManager.UseCases;

namespace TaskManager.Util;

public class MenuCreation
{
    public Menu CreateMenu()
    {
        ITaskReader taskReader = new JsonTaskReader();
        ITaskService taskService = new TaskService(taskReader);
        IParser<Guid,string> parser = new GuidParser();
        TaskHandler taskHandler = new TaskHandler(taskService,parser);
        return new Menu(taskHandler);
    }
}