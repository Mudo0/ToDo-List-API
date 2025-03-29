using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TodoListAPI.Abstractions
{
    //clase base para todos los controladores
    public abstract class ApiController : ControllerBase
    {
        protected readonly ISender Sender;

        protected ApiController(ISender sender)
        {
            Sender = sender;
        }
    }
}