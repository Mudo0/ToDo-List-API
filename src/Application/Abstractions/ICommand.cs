using MediatR;
using SharedKernel;

namespace Application.Abstractions;

//action that does not return a value
public interface ICommand : IRequest<Result>, IBaseCommand
{
}

//action that does return a value
public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
{
}

//generic base for injecting any command type
public interface IBaseCommand
{
}