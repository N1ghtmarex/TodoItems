using Abstractions.CommonModels;
using Application.TodoItem.Commands;
using Application.TodoItem.Dtos;
using Application.TodoItem.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/admin/todoitems")]
    public class TodoItemController(ISender sender): BaseController
    {
        [HttpPost]
        public async Task<CreateTodoItemEntityViewModel> CreateTodoItem([FromQuery] CreateTodoItemCommand command,
            CancellationToken cancellationToken)
        {
            return await sender.Send(command, cancellationToken);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTodoItem([FromQuery] UpdateTodoItemCommand command, CancellationToken cancellationToken)
        {
            await sender.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTodoItem([FromQuery] DeleteTodoItemCommand command,
            CancellationToken cancellationToken)
        {
            await sender.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpGet("{Id}")]
        public async Task<TodoItemViewModel> GetTodoItem([FromQuery] GetTodoItemQuery query,
            CancellationToken cancellationToken)
        {
            return await sender.Send(query, cancellationToken);
        }

        [HttpGet]
        public async Task<TodoItemListViewModel> GetTodoItems(CancellationToken cancellationToken)
        {
            return await sender.Send(new GetTodoItemsListQuery {}, cancellationToken);
        }
    }
}
