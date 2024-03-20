using Application.TodoItem.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.TodoItem.Commands
{
    public class DeleteTodoItemCommand : IRequest
    {
        [FromBody]
        public required DeleteTodoItemModel Body { get; set; }
    }
}
