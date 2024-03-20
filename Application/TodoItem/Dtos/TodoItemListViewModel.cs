namespace Application.TodoItem.Dtos
{
    public class TodoItemListViewModel
    {
        public required List<Domain.Entities.TodoItem> TodoItems { get; set; }
    }
}
