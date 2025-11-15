using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Persistence;

namespace Infraestructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        public async Task CreateAsync(User user)
        {
            await context.Users.AddAsync(user);
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await context.Users.FindAsync(id);
        }
    }
}