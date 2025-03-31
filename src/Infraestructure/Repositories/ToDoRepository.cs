using Domain.DTOs;
using Domain.Events;
using Domain.Interfaces.Repositories;
using Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Infraestructure.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly IApplicationDbContext _context;

        public ToDoRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<ToDoDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ToDoDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ToDoDto item)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Guid>> CreateAsync(ToDoDto dto, CancellationToken cancellationToken)
        {
            var toDo = dto.Convert();

            _context.ToDos.Add(toDo);
            toDo.Raise(new ItemCreatedEvent(toDo.Id));
            await _context.SaveChangesAsync(cancellationToken);
            //todo agregar failure path
            return Result.Success(toDo.Id);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}