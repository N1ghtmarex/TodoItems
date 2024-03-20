using Abstractions.CommonModels;
using Application.TodoItem.Commands;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.TodoItem.Handlers
{
    internal class TodoItemCommandsHandler(ApplicationDbContext dbContext) : IRequestHandler<CreateTodoItemCommand, CreateTodoItemEntityViewModel>, 
        IRequestHandler<UpdateTodoItemCommand>, IRequestHandler<DeleteTodoItemCommand>
    {
        public async Task<CreateTodoItemEntityViewModel> Handle(CreateTodoItemCommand request,
            CancellationToken cancellationToken)
        {
            var todoItemWithSameName = await dbContext.TodoItems
                .Where(x => x.Name.ToLower() == request.Body.Name.ToLower())
                .SingleOrDefaultAsync(cancellationToken);

            if (todoItemWithSameName != null)
            {
                throw new Exception("Already exists");
            }

            var todoItem = new Domain.Entities.TodoItem
            {
                Name = request.Body.Name
            };

            await dbContext.AddAsync(todoItem, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateTodoItemEntityViewModel
            {
                Name = todoItem.Name
            };
        }

        public async Task Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await dbContext.TodoItems.FirstOrDefaultAsync(x => x.Id == request.Body.Id, cancellationToken);

            if (todoItem == null)
            {
                throw new Exception("not found");
            }

            if (request.Body.Name != "" )
            {
                todoItem.Name = request.Body.Name;
            }

            todoItem.IsComplete = request.Body.IsComplete;

            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await dbContext.TodoItems.FirstOrDefaultAsync(x => x.Id == request.Body.Id, cancellationToken);

            if (todoItem == null)
            {
                throw new Exception("not found");
            }

            dbContext.TodoItems.Remove(todoItem);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
