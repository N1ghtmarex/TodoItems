using Application.Common.Mapping;
using AutoMapper;

namespace Application.TodoItem.Dtos
{
    public class TodoItemViewModel : IMapWith<Domain.Entities.TodoItem>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsComplete { get; set; } = false;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.TodoItem, TodoItemViewModel>();
        }
    }
}
