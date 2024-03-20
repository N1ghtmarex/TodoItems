using Application.TodoItem.Dtos;
using MediatR;

namespace Application.TodoItem.Queries
{
    public class GetTodoItemsListQuery : IRequest<TodoItemListViewModel>
    {
    }
}
