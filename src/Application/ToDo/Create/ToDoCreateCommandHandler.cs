using Application.Abstractions;
using Domain.Interfaces.Repositories;
using SharedKernel;

namespace Application.ToDo.Create
{
    //handler type of the command we want to handle
    public class ToDoCreateCommandHandler : ICommandHandler<ToDoCreateCommand, Guid>
    {
        private readonly IToDoRepository _repository;

        public ToDoCreateCommandHandler(IToDoRepository repository)
        {
            _repository = repository;
        }

        //method to decide what and how to do with the command
        public async Task<Result<Guid>> Handle(ToDoCreateCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.CreateAsync(request.Dto, cancellationToken);
            //todo agregar failure path
            return Result.Success(result.Value);
        }
    }
}