using Abstractions.CommonModels;
using Application.TodoItem.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.TodoItem.Queries
{
    public class GetTodoItemQuery : IRequest<TodoItemViewModel>
    {
        [FromRoute]
        public required Guid Id { get; set; }
    }
}
