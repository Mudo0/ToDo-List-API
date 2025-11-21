using ErrorOr;

namespace Application.Common.Abstractions.CQRS
{
    /// <summary>
    /// Clase command que no devuelve nada
    /// </summary>
    public interface ICommand : ICommand<Success>
    {
    }

    /// <summary>
    /// Clase command que devuelve una respuesta
    /// </summary>
    /// <typeparam name="TResponse">
    /// Respuesta genérica, puede ser tanto un valor como un tipo</typeparam>
    public interface ICommand<out TResponse> : IBaseRequest<TResponse>
    {
    }
}