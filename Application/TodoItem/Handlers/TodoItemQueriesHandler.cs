using Abstractions.CommonModels;
using Application.TodoItem.Dtos;
using Application.TodoItem.Queries;
using MediatR;
using Domain;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Application.TodoItem.Handlers
{
    internal class TodoItemQueriesHandler(ApplicationDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetTodoItemQuery, TodoItemViewModel>, IRequestHandler<GetTodoItemsListQuery, TodoItemListViewModel>
    {
        public async Task<TodoItemViewModel> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
        {
            var todoItem = await dbContext.TodoItems.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (todoItem == null)
            {
                throw new Exception("not found");
            }

            return mapper.Map<TodoItemViewModel>(todoItem);
        }

        public async Task<TodoItemListViewModel> Handle(GetTodoItemsListQuery request, CancellationToken cancellationToken)
        {
            var todoItems = await dbContext.TodoItems.ProjectTo<TodoItemViewModel>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new TodoItemListViewModel
            {
                TodoItems = todoItems
            };
        }
    }
}
