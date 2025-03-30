using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infraestructure.Data.Context;

namespace Infraestructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> LoginAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}