using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;

namespace Domain.Interfaces.Repositories
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDoDto>> GetAllAsync();

        Task<ToDo> GetByIdAsync(int id);

        Task<bool> UpdateAsync(ToDoDto item);

        Task<bool> CreateAsync(ToDoDto item);

        Task<bool> DeleteAsync(int id);
    }
}