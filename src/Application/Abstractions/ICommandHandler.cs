using MediatR;
using SharedKernel;

namespace Application.Abstractions;

//interface for commands that does not return a value
public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
    //method to decide what to do with the command
    //returns a result class with the success or failure of the command
    Task<Result> Handle(TCommand command, CancellationToken cancellationToken);
}

//interface for handling commands that return a value
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
    Task<Result<TResponse>> Handle(TCommand command, CancellationToken cancellationToken);
}