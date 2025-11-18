using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class TodoRepository(ApplicationDbContext context) : ITodoRepository
    {
        public async Task<TodoItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await context.TodoItems.FirstOrDefaultAsync(
                todo => todo.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<TodoItem>> GetByUserIdAsync(
            Guid id, CancellationToken cancellationToken)
        {
            return await context.TodoItems.Where(t => t.UserId == id)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync(
            CancellationToken cancellationToken)
        {
            return await context.TodoItems.ToListAsync(cancellationToken);
        }

        public async Task AddAsync(TodoItem entity, CancellationToken cancellationToken)
        {
            await context.TodoItems.AddAsync(entity, cancellationToken);
        }

        public void UpdateAsync(TodoItem entity)
        {
            context.TodoItems.Update(entity);
        }

        public void DeleteAsync(TodoItem entity)
        {
            context.TodoItems.Remove(entity);
        }
    }
}