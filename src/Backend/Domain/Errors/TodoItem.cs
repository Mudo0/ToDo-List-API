using ErrorOr;

namespace Domain.Errors;

public static partial class DomainErrors
{
    /// <summary>
    /// Clase estática para definir y acceder a los errores relacionados con la entidad TodoItem.
    /// </summary>
    public static class TodoItem
    {
        public static Error TitleTooLong() =>
            Error.Validation(
                code: "TodoItem.Title",
                description: "The title cannot be over 100 characters.");

        public static Error TitleEmptyOrWhiteSpace() =>
            Error.Validation(
                code: "TodoItem.Title",
                description: "The title cannot be empty");

        public static Error InvalidUserId() =>
            Error.Validation(
                code: "TodoItem.InvalidUser",
                description: "The user id is not valid or empty");

        public static Error InvalidDate() =>
            Error.Validation(
                code: "TodoItem.LimitDate",
                description: "The date cannot be previous from today");

        public static Error CompleteACancelledTask() =>
            Error.Conflict(
                code: "TodoItem.Cancelled",
                description: "A cancelled task cannot be completed");

        public static Error StartProgressACancelledTask() =>
            Error.Conflict(
                code: "TodoItem.Status",
                description: "A cancelled task cannot be in progress");

        public static Error CancelACompleteTask() =>
            Error.Conflict(
                code: "TodoItem.Status",
                description: "A completed task cannot be cancelled");
    }
}