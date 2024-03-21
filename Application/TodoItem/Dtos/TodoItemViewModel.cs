using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities;

namespace Abstractions.CommonModels
{
    public class TodoItemViewModel : IMapWith<TodoItem>
    {
        public string Name { get; set; } = string.Empty;
        public bool IsComplete { get; set; } = false;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoItem, TodoItemViewModel>();
        }
    }
}
