using Application.Common.Abstractions.CQRS;
using ErrorOr;

namespace Application.Common.Abstractions.Mediator
{
    /// <summary>
    /// Interfaz que representa un emisor de comandos o consultas.
    /// </summary>
    public interface ISender
    {
        /// <summary>
        /// Método sender para cualquier solicitud que implemente IBaseRequest.
        /// </summary>
        /// <typeparam name="TRequest">Tipo de solicitud</typeparam>
        /// <typeparam name="TResponse">Tipo de respuesta</typeparam>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ErrorOr<TResponse>> SendAsync<TRequest, TResponse>(TRequest request,
            CancellationToken cancellationToken = default)
            where TRequest : IBaseRequest<TResponse>;
    }
}