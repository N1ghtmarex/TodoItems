using Application.TodoItem.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.TodoItem.Commands
{
    public class UpdateTodoItemCommand: IRequest
    {
        [FromBody]
        public required UpdateTodoItemModel Body { get; set; }
    }
}
