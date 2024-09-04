namespace TaskManager.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public TaskPriority Priority { get; set; }
        public bool IsCompleted { get; set; }

        public static TodoItem CreateMedium(string title, string description)
        {
            return new TodoItem { Id = Guid.NewGuid(), Title = title, Description = description, Priority = TaskPriority.Medium };
        }

        public static TodoItem CreateHight(string title, string description)
        {
            return new TodoItem { Id = Guid.NewGuid(), Title = title, Description = description, Priority = TaskPriority.High };
        }

        public static TodoItem CreateLow(string title, string description)
        {
            return new TodoItem { Id = Guid.NewGuid(), Title = title, Description = description, Priority = TaskPriority.Low };
        }
    }

    public enum TaskPriority
    {
        High = 1, Medium = 2, Low = 3
    }
}
