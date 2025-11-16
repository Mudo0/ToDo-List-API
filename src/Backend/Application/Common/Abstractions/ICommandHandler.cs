using ErrorOr;

namespace Application.Common.Abstractions
{
    /// <summary>
    /// Interfaz para el handle de cada comando
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public interface ICommandHandler<in TCommand>
            where TCommand : ICommand
    {
        Task<ErrorOr<Success>> HandleAsync(TCommand command,
            CancellationToken cancellationToken);
    }

    public interface ICommandHandler<in TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
        Task<ErrorOr<TResponse>> HandleAsync(TCommand command,
            CancellationToken cancellationToken);
    }
}