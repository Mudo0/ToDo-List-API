using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Abstractions;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiController
    {
        public UsersController(ISender sender) : base(sender)
        {
        }
    }
}