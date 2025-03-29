using Domain.DTOs;
using SharedKernel;

namespace Domain.Interfaces.Repositories
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDoDto>> GetAllAsync();

        Task<ToDoDto> GetByIdAsync(Guid id);

        Task<bool> UpdateAsync(ToDoDto item);

        Task<Result<Guid>> CreateAsync(ToDoDto dto, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(Guid id);
    }
}