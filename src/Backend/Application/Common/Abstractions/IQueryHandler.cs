using ErrorOr;

namespace Application.Common.Abstractions;

/// <summary>
///Interfaz para el handler de cada consulta.
/// </summary>
/// <typeparam name="TQuery">Tipo de consulta a manejar</typeparam>
/// <typeparam name="TResponse">Tipo de respuesta que devuelve</typeparam>
public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    /// <summary>
    /// Maneja la consulta específica y devuelve una respuesta o un error.
    /// </summary>
    /// <param name="query">Instancia de la consulta a manejar</param>
    /// <param name="cancellationToken">Token de cancelación para la transacción asíncrona</param>
    /// <returns></returns>
    Task<ErrorOr<TResponse>> HandleAsync(TQuery query, CancellationToken cancellationToken);
}