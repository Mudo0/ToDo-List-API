using ErrorOr;

namespace Application.Common.Abstractions.Errors
{
    public static partial class ApplicationErrors
    {
        public class Sender
        {
            public static Error HandlerNotFound() =>
                Error.NotFound(
                    code: "Sender.HandlerNotFound",
                    description: "Handler not found for the given request."
                );
        }
    }
}