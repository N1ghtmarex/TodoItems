namespace Application.TodoItem.Dtos
{
    public class UpdateTodoItemModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsComplete { get; set; } = false;
    }
}
