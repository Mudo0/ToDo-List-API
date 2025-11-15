using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITodoRepository
    {
        /// <summary>
        /// Busca una Tarea por su ID.
        /// </summary>
        Task<TodoItem?> GetByIdAsync(Guid id);

        /// <summary>
        /// Obtiene todas las tareas de un usuario específico.
        /// </summary>
        Task<IEnumerable<TodoItem>> GetByUserIdAsync(Guid id);

        /// <summary>
        /// Obtiene todas las tareas
        /// </summary>
        Task<IEnumerable<TodoItem>> GetAllAsync();

        /// <summary>
        /// Agrega una nueva Tarea al DbContext (no la guarda).
        /// </summary>
        Task CreateAsync(TodoItem entity);

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