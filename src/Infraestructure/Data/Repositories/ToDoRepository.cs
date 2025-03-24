using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ApplicationDbContext _context;

        public ToDoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> CreateAsync(ToDo item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToDo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ToDo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ToDo item)
        {
            throw new NotImplementedException();
        }
    }
}