using TaskManager.Domain.Errors;
using TaskManager.Interfaces;
using TaskManager.UseCases;

namespace TaskManager.Util;

public class Menu
{
    private TaskHandler _taskHandler;
    private ConsoleKeyInfo _key;
    public Menu(TaskHandler taskHandler)
    {
        _taskHandler = taskHandler;   
    }
    
    public void Display()
    {
        while (_key.Key != ConsoleKey.Q)
        {
            Console.Clear();
            Console.WriteLine("Welcome to your Task manager!");
            Console.WriteLine("Write a new task");
            
            string? cmd = Console.ReadLine();
            
            if (cmd is not null)
            {
                string[] cmds = cmd.Split(" ");

                try
                {
                    _taskHandler.HandleTask(cmds);
                }
                catch (AppException appException)
                {
                    Message.PrintError(appException.Message);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue or Q to exit.");
            _key = Console.ReadKey();
        }
        
    }
}