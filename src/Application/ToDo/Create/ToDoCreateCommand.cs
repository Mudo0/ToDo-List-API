using Application.Abstractions;
using Domain.DTOs;

namespace Application.ToDo.Create;

public sealed record ToDoCreateCommand(ToDoDto Dto) : ICommand<Guid>
{
}