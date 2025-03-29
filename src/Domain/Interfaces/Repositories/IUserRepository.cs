using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> LoginAsync(Guid id);

        Task<bool> RegisterAsync(User user);

        Task<bool> UpdateAsync(User user);

        Task<bool> DeleteAsync(int id);
    }
}