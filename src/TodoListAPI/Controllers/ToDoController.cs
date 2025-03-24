using Domain.Entities;
using Infraestructure.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        public ApplicationDbContext _context;

        public ToDoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> Get()
        {
            var result = await _context.ToDos.ToListAsync();
            //if (result.Count == 0 || result == null) { return StatusCode(500, "Error"); }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<object>>> Update()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ToDo>>> Create([FromBody] ToDo entity)
        {
            _context.ToDos.Add(entity);
            var result = await _context.SaveChangesAsync();
            if (result != 1) { return StatusCode(500, "Error"); }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<object>>> Delete()
        {
            throw new NotImplementedException();
        }
    }
}