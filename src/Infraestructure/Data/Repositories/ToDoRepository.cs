using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;
using SharedKernel;

namespace Infraestructure.Data.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ApplicationDbContext _context;

        public ToDoRepository(ApplicationDbContext context)
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

        public Task<Result<Guid>> CreateAsync(ToDoDto dto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}