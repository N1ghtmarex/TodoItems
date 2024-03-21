using Abstractions.CommonModels;

namespace Application.TodoItem.Dtos
{
    public class TodoItemListViewModel
    {
        public required List<TodoItemViewModel> TodoItems { get; set; }
    }
}
