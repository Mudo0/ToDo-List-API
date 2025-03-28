using SharedKernel;

namespace Application.Abstractions;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    //method to decide what to do with the command
    //returns a result class with the success or failure of the command
    Task<Result> HandleAsync(TCommand command, CancellationToken cancellationToken);
}

public interface ICommandHandler<in TCommand, TResponse> where TCommand : ICommand<TResponse>
{
    //for commands that return a value
    Task<Result<TResponse>> HandleAsync(TCommand command, CancellationToken cancellationToken);
}