using Abstractions.CommonModels;
using Application.TodoItem.Dtos;
using Application.TodoItem.Queries;
using MediatR;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.TodoItem.Handlers
{
    internal class TodoItemQueriesHandler(ApplicationDbContext dbContext)
        : IRequestHandler<GetTodoItemQuery, TodoItemViewModel>, IRequestHandler<GetTodoItemsListQuery, TodoItemListViewModel>
    {
        public async Task<TodoItemViewModel> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
        {
            var todoItem = await dbContext.TodoItems.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (todoItem == null)
            {
                throw new Exception("not found");
            }

            return new TodoItemViewModel
            {
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
        }

        public async Task<TodoItemListViewModel> Handle(GetTodoItemsListQuery request, CancellationToken cancellationToken)
        {
            var todoItems = await dbContext.TodoItems.ToListAsync(cancellationToken);

            return new TodoItemListViewModel
            {
                TodoItems = todoItems
            };
        }
    }
}
