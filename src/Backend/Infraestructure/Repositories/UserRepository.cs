using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await context.Users.AddAsync(user, cancellationToken);
        }

        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await context.Users.FirstOrDefaultAsync(
                user => user.Id == id, cancellationToken);
        }
    }
}