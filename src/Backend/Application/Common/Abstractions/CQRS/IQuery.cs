namespace Application.Common.Abstractions.CQRS
{
    /// <summary>
    /// Interfaz para las consultas.
    /// </summary>
    /// <typeparam name="TResponse">Tipo de respuesta esperada de la consulta</typeparam>
    public interface IQuery<out TResponse> : IBaseRequest<TResponse>
    {
    }
}