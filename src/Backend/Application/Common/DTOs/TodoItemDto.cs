using Domain.Entities;

namespace Application.Common.DTOs
{
    /// <summary>
    /// DTO para transportar datos de un <see cref="TodoItem"/>.
    /// </summary>
    /// <param name="Id">Identificador de la tarea</param>
    /// <param name="Title">Titulo de la tarea</param>
    /// <param name="Status">Estado de la tarea</param>
    /// <param name="UserId">Usuario al que pertenece</param>
    public record TodoItemDto(Guid Id, string Title, TodoStatus Status, Guid UserId);
}