using Application.Common.Abstractions.CQRS;
using Application.Common.Abstractions.Errors;
using ErrorOr;
using Microsoft.Extensions.Logging;

namespace Application.Common.Abstractions.Mediator
{
    /// <summary>
    /// Implementación del mediador / emisor de comandos y consultas.
    /// </summary>
    /// <param name="provider"></param>
    public class Sender(IServiceProvider provider, ILogger<Sender> logger) : ISender
    {
        public async Task<ErrorOr<TResponse>> SendAsync<TRequest, TResponse>(
            TRequest request,
            CancellationToken cancellationToken = default)
            where TRequest : IBaseRequest<TResponse>
        {
            // 1) obtención del nombre de la solicitud
            // para el mostrarla en el logger u otro lado

            var requestName = typeof(TRequest).Name;
            try
            {
                logger.LogInformation("Iniciando solicitud: {RequestName}", requestName);

                // 2) obtención del tipo explícito de handler
                var handlerType = typeof(IRequestHandler<TRequest, TResponse>);

                // 3) intento de buscarlo con el provider
                var handler = provider.GetService(handlerType);
                // 4) si es null, no lo encontró
                if (handler is null)
                {
                    logger.LogWarning(
                        "No se encontró el handler para la solicitud: {RequestName}",
                        requestName);

                    //retorno error
                    return ApplicationErrors.Sender.HandlerNotFound(requestName);
                }

                // 5) conversion al tipo específico de handler
                var typedHandler = (IRequestHandler<TRequest, TResponse>)handler;

                // 6) ejecución del handle()
                var result = await typedHandler.HandleAsync(request, cancellationToken);

                // 7) logging del resultado si fue exitoso o falló
                if (result.IsError)
                {
                    logger.LogWarning(
                        "Solicitud {RequestName} finalizó con errores de dominio {Errors}",
                        requestName, result.Errors);
                }
                else
                {
                    logger.LogInformation("Solicitud {RequestName} finalizada con éxito.",
                        requestName);
                }

                //retorno del resultado del handle()
                return result;
            }

            //excepción inesperada en caso de que algo falle
            catch (Exception ex)
            {
                logger.LogError(
                    ex, "Error critico no manejado al ejecutar la solicitud {RequestName}",
                    requestName);

                return ApplicationErrors.Sender.UnhandledException(requestName);
            }
        }
    }
}