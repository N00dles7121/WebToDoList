namespace WebApp.Models
{
    public class TaskToDo
    {
        public int Id { get; set; }
        public string Body { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? EditedOn { get; set; }
    }
}