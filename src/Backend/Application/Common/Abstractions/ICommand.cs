namespace Application.Common.Abstractions
{
    /// <summary>
    /// Clase command que no devuelve nada
    /// </summary>
    public interface ICommand : IBaseCommand
    {
    }

    /// <summary>
    /// Clase command que devuelve una respuesta
    /// </summary>
    /// <typeparam name="TResponse">
    /// Respuesta genérica, puede ser tanto un valor como un tipo</typeparam>
    public interface ICommand<TResponse> : IBaseCommand
    {
    }

    /// <summary>
    /// Clase base para los comandos.
    /// Con esta se pueden definir handlers
    /// genericos sin necesidad de especificar que tipo de command voy a usar
    /// </summary>
    public interface IBaseCommand
    {
    }
}