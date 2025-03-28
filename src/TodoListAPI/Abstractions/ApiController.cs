using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TodoListAPI.Abstractions
{
    //clase base para todos los controladores
    public abstract class ApiController : ControllerBase
    {
        protected readonly ISender _sender;

        protected ApiController(ISender sender)
        {
            _sender = sender;
        }
    }
}