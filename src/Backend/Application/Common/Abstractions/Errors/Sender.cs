using ErrorOr;

namespace Application.Common.Abstractions.Errors
{
    public static partial class ApplicationErrors
    {
        /// <summary>
        /// Clase estática que define los errores del mediador / emisor.
        /// </summary>
        public static class Sender
        {
            /// <summary>
            /// Error que indica que no se encontró un handler registrado para la request dada.
            /// </summary>
            /// <param name="requestName">Request del handler solicitado</param>
            /// <returns>ErrOr type</returns>
            public static Error HandlerNotFound(string requestName) =>
                Error.Unexpected(
                    code: "Sender.HandlerNotFound",
                    description: $"No registered handler was found " +
                                 $"for the given request: {requestName} "
                );

            /// <summary>
            /// Error inesperado para las excepciones no controladas en el mediador.
            /// </summary>
            /// <param name="requestName">Request que se estaba procesando al momento de la excepción</param>
            /// <returns>ErrOr type</returns>
            public static Error UnhandledException(string requestName) =>
                Error.Unexpected(
                    code: "Sender.Exception",
                    description: $"An unexpected error " +
                                 $"occurred in the server while processing: {requestName}");
        }
    }
}