using Application.Abstractions;
using Application.ToDo.Create;
using Domain.DTOs;

using Infraestructure.Data.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedKernel;
using TodoListAPI.Abstractions;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly ICommandHandler<ICommand> _handler;

        //hereda el Isender desde la clase base
        public ToDoController(ApplicationDbContext context, ISender sender) : base(sender)
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
        public async Task<IActionResult> Create([FromBody] ToDoDto dto,
            CancellationToken cancellationToken)
        {
            //creamos el comando
            var command = new ToDoCreateCommand(dto);

            //lo enviamos para que lo maneje el handler
            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Ok(result) : StatusCode(
                    CustomEndpointError.GetStatusCode(result.Error.Type),
            //custom detailed result error
                CustomEndpointError.Problem(result));
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<object>>> Delete()
        {
            throw new NotImplementedException();
        }
    }
}