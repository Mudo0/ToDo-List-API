using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDo>> GetAllAsync();

        Task<ToDo> GetByIdAsync(int id);

        Task<bool> UpdateAsync(ToDo item);

        Task<bool> CreateAsync(ToDo item);

        Task<bool> DeleteAsync(int id);
    }
}