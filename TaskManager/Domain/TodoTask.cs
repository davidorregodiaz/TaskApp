using TaskManager.Util;

namespace TaskManager.Domain;

public class TodoTask
{
    public TodoTask() {}

    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Description { get; set; }
    public Status Status { get; set; } = Status.Todo; 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
    
}