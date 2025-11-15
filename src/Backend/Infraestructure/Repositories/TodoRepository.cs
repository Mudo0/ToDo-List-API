using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class TodoRepository(ApplicationDbContext context) : ITodoRepository
    {
        public async Task<TodoItem?> GetByIdAsync(Guid id)
        {
            return await context.TodoItems.FindAsync(id);
        }

        public async Task<IEnumerable<TodoItem>> GetByUserIdAsync(Guid id)
        {
            return await context.TodoItems.Where(t => t.UserId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await context.TodoItems.ToListAsync();
        }

        public async Task CreateAsync(TodoItem entity)
        {
            await context.TodoItems.AddAsync(entity);
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