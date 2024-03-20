using Abstractions.CommonModels;
using Application.TodoItem.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.TodoItem.Commands
{
    public class CreateTodoItemCommand: IRequest<CreateTodoItemEntityViewModel>
    {
        [FromBody]
        public required CreateTodoItemModel Body { get; set; }
    }
}
