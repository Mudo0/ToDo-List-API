using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITodoRepository
    {
        /// <summary>
        /// Busca una Tarea por su ID.
        /// </summary>
        Task<TodoItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Obtiene todas las tareas de un usuario específico.
        /// </summary>
        Task<IEnumerable<TodoItem>> GetByUserIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Obtiene todas las tareas
        /// </summary>
        Task<IEnumerable<TodoItem>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Agrega una nueva Tarea al DbContext (no la guarda).
        /// </summary>
        Task AddAsync(TodoItem entity, CancellationToken cancellationToken);

        /// <summary>
        /// Marca una Tarea como modificada en el DbContext (no la guarda).
        /// </summary>
        void UpdateAsync(TodoItem entity);

        /// <summary>
        /// Marca una Tarea como eliminada en el DbContext (no la guarda).
        /// </summary>
        void DeleteAsync(TodoItem entity);
    }
}