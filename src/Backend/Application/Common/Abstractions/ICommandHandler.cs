using ErrorOr;

namespace Application.Common.Abstractions
{
    /// <summary>
    /// Interfaz para el handler de cada comando sin respuesta.
    /// </summary>
    /// <typeparam name="TCommand">Comando al que se le va a implementar el método handle</typeparam>
    public interface ICommandHandler<in TCommand>
            where TCommand : ICommand
    {
        /// <summary>
        /// Maneja el comando específico y devuelve success o un error.
        /// </summary>
        /// <param name="command">Instancia del comando a manejar</param>
        /// <param name="cancellationToken">Token de cancelación para la transacción asíncrona</param>
        /// <returns></returns>
        Task<ErrorOr<Success>> HandleAsync(TCommand command,
            CancellationToken cancellationToken);
    }

    /// <summary>
    /// Interfaz para el handler de cada comando con respuesta.
    /// </summary>
    /// <typeparam name="TCommand">Comando al que se le va a implementar el método handle</typeparam>
    /// <typeparam name="TResponse">Respuesta que devuelve el comando</typeparam>
    public interface ICommandHandler<in TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
        /// <summary>
        /// Maneja el comando específico y devuelve una respuesta o un error.
        /// </summary>
        /// <param name="command">Instancia del comando a manejar</param>
        /// <param name="cancellationToken">Token de cancelación para la transacción asíncrona</param>
        /// <returns></returns>
        Task<ErrorOr<TResponse>> HandleAsync(TCommand command,
            CancellationToken cancellationToken);
    }
}