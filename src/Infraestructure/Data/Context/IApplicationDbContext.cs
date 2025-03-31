using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Context;

public interface IApplicationDbContext
{
    DbSet<ToDo> ToDos { get; set; }
    DbSet<ToDoProgress> ToDoProgresses { get; set; }
    DbSet<User> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}