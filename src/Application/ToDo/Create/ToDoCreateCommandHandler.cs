using Application.Abstractions;
using Domain.Errors;
using Domain.Interfaces.Repositories;
using SharedKernel;

namespace Application.ToDo.Create
{
    //handler type of the command we want to handle
    public class ToDoCreateCommandHandler : ICommandHandler<ToDoCreateCommand>
    {
        private readonly IToDoRepository _repository;

        public ToDoCreateCommandHandler(IToDoRepository repository)
        {
            _repository = repository;
        }

        //method to decide what and how to do with the command
        public async Task<Result> HandleAsync(ToDoCreateCommand command, CancellationToken cancellationToken)
        {
            var itemToCreate = command.dto;

            if (!await _repository.CreateAsync(itemToCreate))
            {
                return ItemErrors.NotInserted();
            }
            return Result.Success();
        }
    }
}