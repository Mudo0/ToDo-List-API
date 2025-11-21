using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;

namespace Application.Common.Abstractions.CQRS
{
    /// <summary>
    /// Interfaz para el handler genérico de cada request.
    /// </summary>
    /// <typeparam name="TRequest">Comando o query</typeparam>
    /// <typeparam name="TResponse">Tipo de respuesta</typeparam>
    public interface IRequestHandler<in TRequest, TResponse>
        where TRequest : IBaseRequest<TResponse>
    {
        Task<ErrorOr<TResponse>> HandleAsync(TRequest request,
            CancellationToken cancellationToken = default);
    }
}