namespace Domain.Entities
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsComplete { get; set; } = false;
    }
}
