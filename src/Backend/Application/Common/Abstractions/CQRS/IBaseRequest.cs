namespace Application.Common.Abstractions.CQRS
{
    /// <summary>
    /// Interfaz base para las solicitudes. Unifica comandos y queries
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public interface IBaseRequest<out TResponse>
    {
    }
}