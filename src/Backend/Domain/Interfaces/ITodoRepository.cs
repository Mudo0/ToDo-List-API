using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task<TodoItem?> GetByIdAsync(Guid id);

        Task<IEnumerable<TodoItem>> GetByUserIdAsync(Guid id);

        Task<IEnumerable<TodoItem>> GetAllAsync();

        Task<TodoItem> CreateAsync(TodoItem entity);

        Task<TodoItem> UpdateAsync(TodoItem entity);

        Task<TodoItem> ChangeStatusAsync(Guid id, TodoStatus status);

        Task<bool> DeleteAsync(Guid id);
    }
}